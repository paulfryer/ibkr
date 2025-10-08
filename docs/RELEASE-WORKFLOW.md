# Release Workflow

This document describes the automated CI/CD pipeline for building, testing, and publishing all three SDK layers: Clean API, NSwag, and Kiota.

## Overview

The release workflow is a **manual GitHub Actions workflow** that:
- ✅ Generates NSwag and Kiota SDKs from the latest OpenAPI spec
- ✅ Builds and packages Clean API, NSwag, and Kiota as NuGet packages
- ✅ Runs comprehensive test suites with mock implementations
- ✅ Creates GitHub releases (optional)
- ✅ Publishes downloadable artifacts

**Three SDK layers published:**
1. **Clean API** (IBKR.Api.Contract, IBKR.Api.Client, IBKR.Api.Authentication) ⭐
2. **NSwag SDK** (IBKR.Api.NSwag.Contract, IBKR.Api.NSwag.Client)
3. **Kiota SDK** (IBKR.Api.Kiota.Contract, IBKR.Api.Kiota.Client)

## Triggering a Release

### Via GitHub UI

1. Go to **Actions** tab: https://github.com/paulfryer/ibkr/actions
2. Select **"Build and Release SDK Packages"** workflow
3. Click **"Run workflow"** button
4. Fill in the parameters:
   - **Release version**: `1.0.0` (semantic versioning)
   - **Create GitHub Release**: ☑️ (optional)
   - **Mark as pre-release**: ☑️ if beta/RC
5. Click **"Run workflow"**

### Via GitHub CLI

```bash
# Basic release (artifacts only)
gh workflow run release.yml \
  -f version=1.0.0

# Create GitHub Release
gh workflow run release.yml \
  -f version=1.0.0 \
  -f create_github_release=true

# Pre-release version
gh workflow run release.yml \
  -f version=1.0.0-beta.1 \
  -f create_github_release=true \
  -f prerelease=true
```

## Version Format

Use **Semantic Versioning (semver)**:

### Valid Examples

✅ `1.0.0` - Major.Minor.Patch
✅ `2.1.5` - Patch update
✅ `1.0.0-beta.1` - Pre-release
✅ `2.0.0-rc.2` - Release candidate
✅ `1.0.0+build.123` - With build metadata

### Invalid Examples

❌ `1.0` - Missing patch version
❌ `v1.0.0` - Don't include 'v' prefix
❌ `1.0.0.0` - Too many segments

## Workflow Jobs

```
1. validate - Validate semver version
    ↓
2. generate-sdks - Generate NSwag + Kiota
    ↓
3. scaffold-tests - Create Mock + Test projects
    ↓
4. build-nswag ←→ 5. build-kiota (parallel)
    ↓
6. build-clean-api ← Depends on NSwag
    ↓
7. test-nswag ←→ 8. test-kiota ←→ 9. test-clean-api (parallel)
    ↓
10. create-summary - Generate release summary
    ↓
11. create-release (optional) - GitHub Release
```

For detailed job descriptions, see [WORKFLOW-UPDATES.md](WORKFLOW-UPDATES.md).

### Job 1: Validate

**Purpose:** Ensure version format is valid

```yaml
- name: 🔍 Validate semver format
  run: |
    if ! echo "${{ inputs.version }}" | grep -qE '^[0-9]+\.[0-9]+\.[0-9]+'; then
      echo "❌ Invalid version format"
      exit 1
    fi
```

### Key Jobs

#### Job 6: Build Clean API

**Purpose:** Build and package the production-ready Clean API layer

**Dependencies:** Needs NSwag to be built first (Clean API uses NSwag packages)

**Outputs:**
- `IBKR.Api.Contract.{version}.nupkg`
- `IBKR.Api.Authentication.{version}.nupkg`
- `IBKR.Api.Client.{version}.nupkg`

#### Job 9: Test Clean API

**Purpose:** Run comprehensive test suite with high-quality logging

**Configuration:**
```yaml
env:
  Testing__UseMockClient: true  # Forces mock mode for CI/CD
```

**Features:**
- Comprehensive logging with ITestOutputHelper
- Descriptive assertion messages
- Try-catch state dumps on failure
- No real API credentials needed

### Job 2: Generate SDKs

**Purpose:** Download OpenAPI spec and generate NSwag and Kiota SDKs

```yaml
- name: 🔧 Generate SDKs
  run: |
    cd src/IBKR.Api.Generator
    echo "0" | dotnet run --configuration Release
```

**Outputs:**
- `src/Kiota/` - Generated Kiota SDK
- `src/NSwag/` - Generated NSwag SDK

### Job 3: Scaffold Tests

**Purpose:** Create test infrastructure

```yaml
- name: 🧪 Scaffold test projects
  run: |
    cd src/IBKR.Api.TestScaffold
    dotnet run --configuration Release
```

**Outputs:**
- MockClient projects (if don't exist)
- Test projects (if don't exist)

### Job 4 & 5: Build SDKs (Parallel)

**Purpose:** Build and package NuGet packages

```yaml
- name: 📦 Pack NuGet packages
  run: |
    dotnet pack \
      --configuration Release \
      --no-build \
      -p:PackageVersion=${{ inputs.version }} \
      --output ./packages
```

**Outputs:**
- `IBKR.Api.NSwag.Contract.{version}.nupkg`
- `IBKR.Api.NSwag.Contract.{version}.snupkg` (symbols)
- `IBKR.Api.NSwag.Client.{version}.nupkg`
- `IBKR.Api.NSwag.Client.{version}.snupkg`
- `IBKR.Api.Kiota.Contract.{version}.nupkg`
- `IBKR.Api.Kiota.Contract.{version}.snupkg`
- `IBKR.Api.Kiota.Client.{version}.nupkg`
- `IBKR.Api.Kiota.Client.{version}.snupkg`

**Artifacts:**
- `NSwag-SDK-v{version}` - 90-day retention
- `Kiota-SDK-v{version}` - 90-day retention

### Job 6 & 7: Test SDKs (Parallel)

**Purpose:** Run tests with mock implementations

```yaml
- name: 🧪 Run tests
  run: |
    dotnet test \
      --configuration Release \
      --logger "trx;LogFileName=test-results.trx" \
      --no-build
```

Tests automatically use mocks via `appsettings.test.json`.

### Job 8: Create Summary

**Purpose:** Generate workflow summary with download instructions

**Output:** Markdown summary with:
- Package versions
- Download commands
- Installation instructions
- GitHub release link (if created)

### Job 9: Create Release (Optional)

**Purpose:** Create GitHub release with packages

If `create_github_release` is enabled:

```yaml
- name: 🚀 Create GitHub Release
  uses: softprops/action-gh-release@v2
  with:
    tag_name: v${{ inputs.version }}
    name: Release v${{ inputs.version }}
    draft: false
    prerelease: ${{ inputs.prerelease }}
    files: |
      packages/*.nupkg
      packages/*.snupkg
```

## Downloading Artifacts

### From Workflow Run

1. Go to **Actions** tab
2. Click on the workflow run
3. Scroll to **Artifacts** section
4. Download:
   - `NSwag-SDK-v1.0.0.zip`
   - `Kiota-SDK-v1.0.0.zip`

### From GitHub Release

If GitHub Release was created:

1. Go to **Releases** page
2. Find release `v1.0.0`
3. Download from **Assets** section

## Installing Packages

### From Local Folder

```bash
# Extract artifact
unzip NSwag-SDK-v1.0.0.zip -d packages

# Install
dotnet add package IBKR.Api.NSwag.Contract --source ./packages --version 1.0.0
dotnet add package IBKR.Api.NSwag.Client --source ./packages --version 1.0.0
```

### From NuGet Feed (After Publishing)

```bash
dotnet add package IBKR.Api.NSwag.Contract --version 1.0.0
dotnet add package IBKR.Api.NSwag.Client --version 1.0.0

dotnet add package IBKR.Api.Kiota.Contract --version 1.0.0
dotnet add package IBKR.Api.Kiota.Client --version 1.0.0
```

## Package Metadata

All packages include:

```xml
<Authors>Paul Fryer</Authors>
<Copyright>Copyright © 2025 IBKR SDK Contributors</Copyright>
<PackageLicenseExpression>MIT</PackageLicenseExpression>
<RepositoryUrl>https://github.com/paulfryer/ibkr.git</RepositoryUrl>
<PackageTags>ibkr;interactive-brokers;trading;api;rest;sdk</PackageTags>
```

Plus project-specific descriptions.

## Publishing to NuGet.org

To publish packages to NuGet.org, add a publish job:

### 1. Get NuGet API Key

1. Go to https://www.nuget.org/account/apikeys
2. Create new API key with push permission
3. Add to GitHub Secrets as `NUGET_API_KEY`

### 2. Add Publish Job

```yaml
publish-nuget:
  name: 📤 Publish to NuGet
  needs: [validate, build-nswag, build-kiota, test-nswag, test-kiota]
  runs-on: ubuntu-latest
  steps:
    - name: Download all artifacts
      uses: actions/download-artifact@v4
      with:
        pattern: '*-SDK-v*'
        path: packages

    - name: Push to NuGet
      run: |
        dotnet nuget push packages/**/*.nupkg \
          --api-key ${{ secrets.NUGET_API_KEY }} \
          --source https://api.nuget.org/v3/index.json \
          --skip-duplicate
```

## Publishing to GitHub Packages

To publish to GitHub Packages instead:

```yaml
publish-github:
  name: 📤 Publish to GitHub Packages
  needs: [validate, build-nswag, build-kiota, test-nswag, test-kiota]
  runs-on: ubuntu-latest
  steps:
    - name: Download all artifacts
      uses: actions/download-artifact@v4
      with:
        pattern: '*-SDK-v*'
        path: packages

    - name: Push to GitHub Packages
      run: |
        dotnet nuget push packages/**/*.nupkg \
          --api-key ${{ secrets.GITHUB_TOKEN }} \
          --source https://nuget.pkg.github.com/${{ github.repository_owner }}/index.json \
          --skip-duplicate
```

## Troubleshooting

### "Invalid version format" Error

**Cause:** Version doesn't follow semver

**Fix:** Use `1.0.0` not `1.0` or `v1.0.0`

### Workflow Fails at Generate Step

**Possible Causes:**
- OpenAPI spec unavailable
- Generator errors

**Debug:**
```bash
# Run generator locally
cd src/IBKR.Api.Generator
dotnet run
```

### Build Warnings Treated as Errors

**Cause:** Release configuration treats warnings as errors

**Fix:**
1. Check build logs for warning details
2. Suppress specific warnings in `Directory.Build.props`
3. Or fix the warnings

### Tests Fail

**Possible Causes:**
- MockClient not fully implemented
- Configuration issues

**Debug:**
```bash
# Run tests locally
cd src
dotnet test --logger "console;verbosity=detailed"
```

### Artifacts Not Created

**Cause:** Pack step failed

**Fix:** Check build job logs for pack errors

## Workflow Permissions

The workflow requires:

```yaml
permissions:
  contents: write   # For creating releases
  packages: write   # For GitHub Packages (if used)
```

## Environment Variables

| Variable | Value | Purpose |
|----------|-------|---------|
| `DOTNET_VERSION` | `8.0.x` | .NET SDK version |
| `CONFIGURATION` | `Release` | Build configuration |
| `DOTNET_SKIP_FIRST_TIME_EXPERIENCE` | `true` | Disable telemetry |
| `DOTNET_CLI_TELEMETRY_OPTOUT` | `true` | Disable telemetry |

## Versioning Strategy

### Semantic Versioning Guidelines

**Major (X.0.0):**
- Breaking API changes
- New OpenAPI spec version with breaking changes

**Minor (1.X.0):**
- New features (backward compatible)
- New endpoints added to API

**Patch (1.0.X):**
- Bug fixes
- Generator improvements
- Documentation updates

**Pre-release (1.0.0-beta.1):**
- Testing new features
- Alpha/Beta/RC releases

## Release Checklist

Before triggering a release:

- [ ] SDKs generate successfully locally
- [ ] All tests pass locally
- [ ] Documentation is up to date
- [ ] CHANGELOG updated (if maintained)
- [ ] Version number decided
- [ ] Ready to create GitHub release? (or just artifacts)

## Next Steps

- **[Contributing Guide](CONTRIBUTING.md)** - Learn how to regenerate SDKs
- **[Architecture](ARCHITECTURE.md)** - Understand the build pipeline

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
