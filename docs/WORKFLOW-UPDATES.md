# Release Workflow Updates for IBKR SDK

This document summarizes the changes made to `.github/workflows/release.yml` to support the new IBKR SDK layer.

## Overview

The workflow now builds, tests, and releases **three distinct SDK layers**:

1. **IBKR SDK** (IBKR.Api.*) - Production-ready abstraction ⭐ **Recommended**
2. **NSwag SDK** (IBKR.Api.NSwag.*) - Lower-level generated SDK
3. **Kiota SDK** (IBKR.Api.Kiota.*) - Lower-level generated SDK

## Changes Made

### 1. Updated JOB 3: scaffold-tests

**What changed:**
- Added IBKR SDK projects to artifact upload

**Why:**
- Ensures IBKR.Sdk.Contract, IBKR.Sdk.Client, IBKR.Sdk.Authentication, and IBKR.Sdk.Tests are available to downstream jobs

**Files included:**
```yaml
path: |
  src/NSwag/
  src/Kiota/
  src/IBKR.Sdk.Contract/         # ← NEW
  src/IBKR.Sdk.Client/            # ← NEW
  src/IBKR.Sdk.Authentication/    # ← NEW
  src/IBKR.Sdk.Tests/             # ← NEW
  src/Directory.Build.props
```

### 2. Added JOB 6: build-clean-api

**Purpose:** Build and package the IBKR SDK layer as NuGet packages

**Dependencies:**
- Needs: `validate`, `scaffold-tests`, `build-nswag`
- Waits for NSwag because IBKR.Sdk.Client depends on NSwag packages

**What it does:**
1. Restores dependencies for Contract, Authentication, and Client
2. Builds all three projects with version number
3. Packs all three as NuGet packages
4. Uploads packages as artifact: `CleanAPI-SDK-v{version}`

**Packages created:**
- `IBKR.Sdk.Contract.{version}.nupkg`
- `IBKR.Sdk.Authentication.{version}.nupkg`
- `IBKR.Sdk.Client.{version}.nupkg`

### 3. Added JOB 9: test-clean-api

**Purpose:** Run comprehensive test suite for IBKR SDK

**Dependencies:**
- Needs: `validate`, `build-clean-api`, `scaffold-tests`

**Configuration:**
```yaml
env:
  Testing__UseMockClient: true  # Forces mock mode for CI/CD
```

**What it does:**
1. Downloads SDKs with tests
2. Runs IBKR.Sdk.Tests with mocks (no real API credentials needed)
3. Generates detailed test results with logging
4. Uploads test results as artifact

**Key feature:**
- Tests automatically use mocks in CI/CD (via environment variable)
- Local development with credentials uses real API
- High-quality logging shows exactly what failed and why

### 4. Updated JOB 10: create-summary

**What changed:**
- Added `build-clean-api` and `test-clean-api` to needs array
- Updated installation instructions to feature IBKR SDK first
- Added descriptions for each SDK layer

**New summary structure:**
```markdown
## 🚀 Installation

### ⭐ IBKR SDK (Recommended)
Strongly-typed, production-ready abstraction...
dotnet add package IBKR.Sdk.Contract
dotnet add package IBKR.Sdk.Client
dotnet add package IBKR.Sdk.Authentication

### NSwag SDK (Lower-level)
Service-oriented architecture...

### Kiota SDK (Lower-level)
Fluent API architecture...
```

### 5. Updated JOB 11: create-release

**What changed:**
- Added `build-clean-api` to needs array
- Updated release body to feature IBKR SDK prominently
- Added "What's New in IBKR SDK" section

**New release highlights:**
- ⭐ Marks IBKR SDK as recommended
- Explains benefits: strongly-typed, comprehensive error handling, built-in workarounds
- Shows IBKR SDK first in installation instructions
- Maintains backward compatibility with NSwag/Kiota SDKs

## Workflow Flow Diagram

```
┌─────────────────────────────────────────────────────┐
│ 1. validate - Validate semver version              │
└─────────────────────────┬───────────────────────────┘
                          │
┌─────────────────────────┴───────────────────────────┐
│ 2. generate-sdks - Generate NSwag + Kiota          │
└─────────────────────────┬───────────────────────────┘
                          │
┌─────────────────────────┴───────────────────────────┐
│ 3. scaffold-tests - Create Mock + Test projects    │
│    Uploads: NSwag, Kiota, + IBKR SDK projects     │
└────┬──────────────────────────────────────┬─────────┘
     │                                       │
┌────┴─────────────┐          ┌─────────────┴──────────┐
│ 4. build-nswag   │          │ 5. build-kiota         │
│    (parallel)    │          │    (parallel)          │
└────┬─────────────┘          └────────────────────────┘
     │
┌────┴──────────────────────────────────────────────────┐
│ 6. build-clean-api ← Depends on NSwag                 │
│    Builds: Contract, Authentication, Client           │
│    Packs: All three as NuGet packages                 │
└────┬───────────────────────┬──────────────┬───────────┘
     │                       │              │
┌────┴────────┐   ┌─────────┴──────┐   ┌──┴───────────────┐
│ 7. test-    │   │ 8. test-       │   │ 9. test-         │
│    nswag    │   │    kiota       │   │    clean-api     │
│  (parallel) │   │  (parallel)    │   │  (parallel)      │
│  with mocks │   │  with mocks    │   │  with mocks      │
└────┬────────┘   └─────────┬──────┘   └──┬───────────────┘
     │                      │              │
     └──────────────┬───────┴──────────────┘
                    │
┌───────────────────┴──────────────────────────────────┐
│ 10. create-summary - Generate release summary        │
│     Shows: All 3 SDK packages + installation guide   │
└───────────────────┬──────────────────────────────────┘
                    │
┌───────────────────┴──────────────────────────────────┐
│ 11. create-release (optional) - GitHub Release       │
│     Publishes: All NuGet packages with IBKR SDK     │
└──────────────────────────────────────────────────────┘
```

## Testing Strategy

### CI/CD (GitHub Actions)
- All tests run with **mocks** (no credentials needed)
- Environment variable `Testing__UseMockClient=true` forces mock mode
- Fast, reliable, repeatable tests

### Local Development
- Tests detect credentials from environment variables
- Uses **real IBKR API** when credentials are available
- Catches real API issues during development
- Configuration in `CleanApiTestFixture.cs`:
  ```csharp
  var hasCredentials = !string.IsNullOrEmpty(Configuration["IBKR:ClientId"]) && ...;
  var forceMock = Configuration.GetValue<bool>("Testing:UseMockClient", false);
  var useMock = forceMock || !hasCredentials;
  ```

## Package Artifacts

After a successful workflow run, three artifact sets are created:

1. **NSwag-SDK-v{version}** (90-day retention)
   - IBKR.Api.NSwag.Contract.{version}.nupkg
   - IBKR.Api.NSwag.Client.{version}.nupkg

2. **Kiota-SDK-v{version}** (90-day retention)
   - IBKR.Api.Kiota.Contract.{version}.nupkg
   - IBKR.Api.Kiota.Client.{version}.nupkg

3. **CleanAPI-SDK-v{version}** (90-day retention) ⭐
   - IBKR.Sdk.Contract.{version}.nupkg
   - IBKR.Sdk.Authentication.{version}.nupkg
   - IBKR.Sdk.Client.{version}.nupkg

## Benefits

### For Developers
- ✅ IBKR SDK is now the default recommendation
- ✅ Strongly-typed models (DateTime, enums, decimals)
- ✅ Comprehensive error messages with context
- ✅ All API quirks handled automatically
- ✅ Production-ready from day one

### For CI/CD
- ✅ Tests run without credentials (mock mode)
- ✅ Fast, reliable builds
- ✅ Parallel job execution (faster workflow)
- ✅ Comprehensive test results with detailed logging

### For Releases
- ✅ Single workflow publishes all three SDK layers
- ✅ Clear guidance on which SDK to use
- ✅ Backward compatible with existing NSwag/Kiota consumers
- ✅ IBKR SDK highlighted as recommended approach

## Migration Path

Existing users can continue using NSwag/Kiota SDKs without changes. New users are guided toward the IBKR SDK:

**Existing (still supported):**
```csharp
var service = new IserverService(...);
var info = await service.InfoAsync(conid);
// Manual parsing, workarounds, etc.
```

**New (recommended):**
```csharp
var optionService = serviceProvider.GetRequiredService<IOptionService>();
var chain = await optionService.GetOptionChainAsync("AAPL", start, end);
// Clean, strongly-typed, handles quirks automatically
```

## Future Enhancements

As new clean methods are added to `IOptionService`:

1. Development happens in `IBKR.Sdk.Contract` + `IBKR.Sdk.Client`
2. Tests are added to `IBKR.Sdk.Tests`
3. Workflow automatically builds, tests, and publishes updates
4. No workflow changes needed for new methods

The workflow is now **extensible** and **maintainable** for long-term development!
