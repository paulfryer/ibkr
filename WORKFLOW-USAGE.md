# GitHub Actions Release Workflow - Usage Guide

## Overview

The `release.yml` workflow automates the building and packaging of both NSwag and Kiota SDK packages for the Interactive Brokers REST API.

## Workflow Features

✅ **Manual Trigger** - Run on-demand with version control
✅ **Parallel Builds** - NSwag and Kiota build simultaneously for speed
✅ **NuGet Packages** - Professional .nupkg packages with symbols
✅ **90-Day Artifacts** - Downloadable packages retained for 90 days
✅ **Optional GitHub Releases** - Automatically create releases with attached packages
✅ **Comprehensive Summaries** - Detailed job summaries with installation commands

## How to Trigger the Workflow

### Via GitHub UI

1. Navigate to **Actions** tab in your repository
2. Click **Build and Release SDK Packages** workflow
3. Click **Run workflow** button
4. Fill in the inputs:
   - **Release version**: Enter semver format (e.g., `1.0.0`, `1.2.3-beta.1`)
   - **Create GitHub Release**: Check to create a GitHub Release (optional)
   - **Mark as pre-release**: Check if this is a pre-release version (optional)
5. Click **Run workflow**

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

The workflow validates version numbers using **semantic versioning (semver)**:

### Valid Examples:
- `1.0.0` - Standard release
- `2.1.5` - Patch update
- `1.0.0-beta.1` - Pre-release
- `2.0.0-rc.2` - Release candidate
- `1.0.0+build.123` - With build metadata

### Invalid Examples:
- `1.0` - Missing patch version
- `v1.0.0` - Don't include 'v' prefix
- `1.0.0.0` - Too many version segments

## What Gets Built

The workflow generates **4 NuGet packages**:

### NSwag SDK (Service-Oriented Architecture)
1. **IBKR.Api.NSwag.Contract** - Models and service interfaces
2. **IBKR.Api.NSwag.Client** - HTTP client implementations

### Kiota SDK (Fluent API Architecture)
3. **IBKR.Api.Kiota.Contract** - Model classes (POCOs)
4. **IBKR.Api.Kiota.Client** - Fluent request builders

Each package includes:
- Main package (`.nupkg`)
- Symbol package (`.snupkg`) for debugging

## Workflow Jobs

```
validate           # Validate semver format
    ↓
generate-sdks      # Generate both SDKs from OpenAPI spec
    ↓
build-nswag  ←→  build-kiota    # Parallel builds
    ↓
create-summary     # Generate markdown summary
    ↓
create-release     # [Optional] Create GitHub Release
```

## Downloading Artifacts

### From Workflow Run

1. Go to **Actions** tab
2. Click on the workflow run
3. Scroll to **Artifacts** section at the bottom
4. Download:
   - `NSwag-SDK-v{version}` - Contains NSwag packages
   - `Kiota-SDK-v{version}` - Contains Kiota packages

### From GitHub Release

If you chose to create a GitHub Release:

1. Go to **Releases** page
2. Find the release (tagged as `v{version}`)
3. Download packages from **Assets** section

## Installing Packages

### From Downloaded Artifacts

Extract the `.zip` file and install locally:

```bash
# Extract the artifact
unzip NSwag-SDK-v1.0.0.zip -d packages

# Install from local folder
dotnet add package IBKR.Api.NSwag.Contract --source ./packages
dotnet add package IBKR.Api.NSwag.Client --source ./packages
```

### From NuGet Feed (After Publishing)

Once published to NuGet.org:

```bash
# NSwag SDK
dotnet add package IBKR.Api.NSwag.Contract --version 1.0.0
dotnet add package IBKR.Api.NSwag.Client --version 1.0.0

# Kiota SDK
dotnet add package IBKR.Api.Kiota.Contract --version 1.0.0
dotnet add package IBKR.Api.Kiota.Client --version 1.0.0
```

## Package Metadata

All packages include:
- **Authors**: Paul Fryer
- **License**: MIT
- **Repository**: https://github.com/paulfryer/ibkr
- **Tags**: ibkr, interactive-brokers, trading, api, rest, sdk
- **Source Link**: Enabled for debugging into SDK source

## Troubleshooting

### "Invalid version format" Error

**Cause**: Version doesn't follow semver format
**Fix**: Use format like `1.0.0`, not `1.0` or `v1.0.0`

### Workflow Fails at Generate Step

**Cause**: Generator errors or OpenAPI spec issues
**Fix**:
1. Check the `generate-sdks` job logs
2. Verify OpenAPI spec is valid
3. Run generator locally first: `cd src/IBKR.Api.Generator && dotnet run`

### Build Warnings Treated as Errors

**Cause**: Generated code has warnings, and Release builds treat warnings as errors
**Fix**:
1. Check build logs for warning details
2. Fix warnings in generator or suppress specific warnings
3. Temporarily remove `TreatWarningsAsErrors` from `Directory.Build.props`

### Missing Packages in Artifacts

**Cause**: Pack step failed silently
**Fix**: Check `build-nswag` and `build-kiota` job logs for pack errors

## Advanced Usage

### Publishing to NuGet.org

To automatically publish packages to NuGet.org, add this job to the workflow:

```yaml
publish-nuget:
  name: 📤 Publish to NuGet
  needs: [validate, build-nswag, build-kiota]
  runs-on: ubuntu-latest
  steps:
    - name: Download packages
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

**Requirements:**
- Add `NUGET_API_KEY` to repository secrets
- Get API key from https://www.nuget.org/account/apikeys

### Publishing to GitHub Packages

Add this to publish to GitHub Packages instead:

```yaml
- name: Push to GitHub Packages
  run: |
    dotnet nuget push packages/**/*.nupkg \
      --api-key ${{ secrets.GITHUB_TOKEN }} \
      --source https://nuget.pkg.github.com/${{ github.repository_owner }}/index.json
```

## Workflow Permissions

The workflow requires these permissions (already configured):

- **contents: write** - For creating releases and tags
- **packages: write** - For publishing packages to GitHub Packages

## Environment Variables

| Variable | Value | Purpose |
|----------|-------|---------|
| `DOTNET_VERSION` | `8.0.x` | .NET SDK version |
| `CONFIGURATION` | `Release` | Build configuration |
| `DOTNET_SKIP_FIRST_TIME_EXPERIENCE` | `true` | Disable telemetry |
| `DOTNET_CLI_TELEMETRY_OPTOUT` | `true` | Disable telemetry |

## Related Files

- `.github/workflows/release.yml` - Main workflow file
- `src/Directory.Build.props` - Shared NuGet metadata
- `src/*/IBKR.Api.*.csproj` - Individual project files with package descriptions

## Support

For issues with the workflow:
1. Check workflow run logs in Actions tab
2. Open an issue at https://github.com/paulfryer/ibkr/issues
3. Include workflow run link and error messages
