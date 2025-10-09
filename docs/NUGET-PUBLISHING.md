# Publishing to NuGet.org

This document explains how to publish the IBKR SDK packages to NuGet.org using the automated GitHub Actions workflow.

## Prerequisites

✅ **Trusted Publishing is configured** on NuGet.org:
- Package owner: `pfryer`
- Publisher: GitHubActions Repository Owner: `paulfryer`
- Repository: `ibkr`
- Workflow: `release.yml`

✅ **GitHub Secret is configured**:
- Secret name: `NUGET_USER`
- Secret value: `pfryer` (your NuGet.org username)
- Location: Repository Settings → Secrets and variables → Actions

This means **no long-lived API keys are needed** - GitHub automatically provides short-lived OIDC tokens for secure publishing.

## How to Publish

### Step 1: Trigger the Workflow

1. Go to the **Actions** tab on GitHub: https://github.com/paulfryer/ibkr/actions
2. Select **"Build and Release SDK Packages"** workflow
3. Click **"Run workflow"** button
4. Fill in the parameters:
   - **Release version**: e.g., `0.3.1` or `1.0.0-beta.1` (must be valid semver)
   - **Create GitHub Release**: ✅ (default: checked)
   - **Publish to NuGet.org**: ✅ (default: checked)
   - **Mark as pre-release**: Auto-detected from version or check manually
5. Click **"Run workflow"**

**Default behavior (just enter version and click):**
- ✅ Creates GitHub Release
- ✅ Publishes to NuGet.org
- ✅ Auto-detects pre-release if version contains `-beta`, `-alpha`, `-rc`, or `-preview`

### Step 2: What Happens

The workflow will:

1. ✅ **Validate** the version format
2. ✅ **Generate** NSwag and Kiota SDKs from OpenAPI spec
3. ✅ **Build** all 6 packages:
   - `IBKR.Sdk.Contract`
   - `IBKR.Sdk.Client`
   - `IBKR.Sdk.Authentication`
   - `IBKR.Api.NSwag.Contract`
   - `IBKR.Api.NSwag.Client`
   - `IBKR.Api.Kiota.Contract`
   - `IBKR.Api.Kiota.Client`
4. ✅ **Test** all packages with mock implementations
5. ✅ **Create GitHub Release** with all packages attached
6. ✅ **Publish to NuGet.org** using Trusted Publishing (OIDC)

### Step 3: Verify Publication

After the workflow completes:

1. Check the **workflow summary** for NuGet.org links to all published packages
2. Verify packages appear at:
   - https://www.nuget.org/packages/IBKR.Sdk.Contract/
   - https://www.nuget.org/packages/IBKR.Sdk.Client/
   - https://www.nuget.org/packages/IBKR.Sdk.Authentication/
   - https://www.nuget.org/packages/IBKR.Api.NSwag.Contract/
   - https://www.nuget.org/packages/IBKR.Api.NSwag.Client/
   - https://www.nuget.org/packages/IBKR.Api.Kiota.Contract/
   - https://www.nuget.org/packages/IBKR.Api.Kiota.Client/

## Publishing Behavior

### When NuGet Publishing Runs

**Publishing to NuGet.org ONLY happens when:**
- ✅ `create_github_release` is checked (true)
- ✅ All tests pass
- ✅ All builds succeed

**Publishing DOES NOT happen when:**
- ❌ `create_github_release` is unchecked (workflow just builds artifacts)
- ❌ Any test fails
- ❌ Any build fails

### Package Deduplication

The workflow uses `--skip-duplicate` flag, so:
- ✅ If a package version already exists on NuGet.org, it will be skipped (no error)
- ✅ Safe to re-run the workflow for the same version

## Versioning Strategy

Follow [Semantic Versioning (semver)](https://semver.org/):

### Production Releases
- `1.0.0` - Initial release
- `1.0.1` - Patch (bug fixes)
- `1.1.0` - Minor (new features, backward compatible)
- `2.0.0` - Major (breaking changes)

### Pre-releases
- `1.0.0-beta.1` - Beta release
- `1.0.0-rc.1` - Release candidate
- `1.0.0-alpha.1` - Alpha release

**Mark as pre-release:** ✅ Check the "Mark as pre-release" box for beta/RC/alpha versions

## Trusted Publishing Security

### How It Works

1. **GitHub generates OIDC token** - Short-lived token with repository identity
2. **NuGet/login action** - Exchanges OIDC token for temporary NuGet API key (~1 hour lifetime)
3. **Publish with temp key** - `dotnet nuget push` uses the temporary API key
4. **Repository-scoped** - Only this repository (`paulfryer/ibkr`) can publish these packages
5. **Only your username** - Uses `NUGET_USER` secret to verify package owner

### Benefits

- ✅ No long-lived API keys stored in GitHub
- ✅ Temporary keys expire automatically (~1 hour)
- ✅ Repository identity verified by OIDC
- ✅ Audit trail in NuGet.org
- ✅ Only your NuGet username needed as a secret

## Troubleshooting

### ❌ "Workflow failed at publish step"

**Possible causes:**
- Trusted Publishing configuration is incorrect
- Package owner doesn't match (`pfryer`)
- `NUGET_USER` secret is missing or incorrect
- Repository name changed

**Fix:**
1. Verify Trusted Publishing settings on NuGet.org
2. Ensure package owner is `pfryer`
3. Check `NUGET_USER` secret is set to `pfryer` in GitHub
4. Check workflow name is exactly `release.yml`

### ❌ "401 Unauthorized" or "API key must be provided"

**Cause:** `NUGET_USER` secret is not configured

**Fix:**
1. Go to GitHub repository Settings → Secrets and variables → Actions
2. Click "New repository secret"
3. Name: `NUGET_USER`
4. Value: `pfryer`
5. Click "Add secret"

### ❌ "Package already exists"

This is **normal behavior** with `--skip-duplicate` flag. The workflow will:
- Skip packages that already exist
- Continue publishing other packages
- Complete successfully

If you need to update an existing version, you must:
1. Delete the version from NuGet.org (only possible within 72 hours)
2. Or publish a new version (recommended)

### ❌ "Tests failed"

Publishing will not run if any tests fail. Check the test results in the workflow summary.

## Manual Publishing (Emergency)

If the automated workflow fails, you can publish manually:

```bash
# 1. Build packages locally
cd src
dotnet build IBKR.Sdk.sln --configuration Release /p:Version=1.0.0

# 2. Pack packages
dotnet pack IBKR.Sdk.Contract/IBKR.Sdk.Contract.csproj -o packages /p:PackageVersion=1.0.0
dotnet pack IBKR.Sdk.Client/IBKR.Sdk.Client.csproj -o packages /p:PackageVersion=1.0.0
dotnet pack IBKR.Sdk.Authentication/IBKR.Sdk.Authentication.csproj -o packages /p:PackageVersion=1.0.0
# ... repeat for all packages

# 3. Publish to NuGet.org
# You'll need a NuGet API key for manual publishing
dotnet nuget push packages/*.nupkg --source https://api.nuget.org/v3/index.json --api-key YOUR_API_KEY
```

**Note:** Manual publishing requires a NuGet API key, which is less secure than Trusted Publishing.

## Next Steps

After publishing:

1. **Announce the release** on GitHub Discussions or Twitter
2. **Update documentation** if needed
3. **Monitor NuGet.org** for download stats and feedback
4. **Respond to issues** on GitHub

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
