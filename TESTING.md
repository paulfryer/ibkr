# Testing Guide

This document explains how to test the IBKR API SDKs with both mock and real credentials.

## Quick Start

By default, all tests use **mock data** and require no credentials:

```bash
dotnet test
```

## Testing with Real IBKR API

To test against the real IBKR API, you need to provide credentials and disable mock mode.

### Step 1: Get Your IBKR Credentials

You'll need the following from your IBKR account:
- **ClientId** - OAuth2 Client ID (e.g., "TESTCONS")
- **Credential** - Your IBKR account username
- **ClientKeyId** - OAuth2 Key Identifier (kid) from IBKR portal
- **ClientPemPath** - Path to your RSA private key PEM file
- **BaseUrl** - API endpoint (default: `https://api.ibkr.com` - trailing slash is optional, it will be added automatically)

### Step 2: Choose Configuration Method

You have two options for providing credentials:

#### Option A: Environment Variables (Recommended)

Set the following environment variables:

**Windows (PowerShell):**
```powershell
$env:Testing__UseMockClient="false"
$env:IBKR__ClientId="YOUR_CLIENT_ID"
$env:IBKR__Credential="YOUR_USERNAME"
$env:IBKR__ClientKeyId="YOUR_KEY_ID"
$env:IBKR__ClientPemPath="C:\path\to\your\key.pem"
```

**Windows (Command Prompt):**
```cmd
set Testing__UseMockClient=false
set IBKR__ClientId=YOUR_CLIENT_ID
set IBKR__Credential=YOUR_USERNAME
set IBKR__ClientKeyId=YOUR_KEY_ID
set IBKR__ClientPemPath=C:\path\to\your\key.pem
```

**Linux/macOS:**
```bash
export Testing__UseMockClient=false
export IBKR__ClientId=YOUR_CLIENT_ID
export IBKR__Credential=YOUR_USERNAME
export IBKR__ClientKeyId=YOUR_KEY_ID
export IBKR__ClientPemPath=/path/to/your/key.pem
```

#### Option B: Configuration File

Edit the `appsettings.json` file in the test project:

**For Kiota tests:** `src/Kiota/IBKR.Api.Kiota.Tests/appsettings.json`
**For NSwag tests:** `src/NSwag/IBKR.Api.NSwag.Tests/appsettings.json`

```json
{
  "Testing": {
    "UseMockClient": false
  },
  "IBKR": {
    "ClientId": "YOUR_CLIENT_ID",
    "Credential": "YOUR_USERNAME",
    "ClientKeyId": "YOUR_KEY_ID",
    "ClientPemPath": "C:\\path\\to\\your\\key.pem",
    "BaseUrl": "https://api.ibkr.com"
  }
}
```

**⚠️ WARNING:** If you edit `appsettings.json`, be careful NOT to commit your credentials to source control! The main `appsettings.json` files are tracked by git.

### Step 3: Store Your PEM File Securely

Place your RSA private key PEM file in a secure location **outside** the repository:

```
C:\Users\YourName\.ibkr\key.pem          # Windows
/home/yourname/.ibkr/key.pem             # Linux
/Users/yourname/.ibkr/key.pem            # macOS
```

Then reference it in your configuration:
- Environment variable: `IBKR__ClientPemPath=C:\Users\YourName\.ibkr\key.pem`
- Or in appsettings.json: `"ClientPemPath": "C:\\Users\\YourName\\.ibkr\\key.pem"`

### Step 4: Run Tests

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test src/Kiota/IBKR.Api.Kiota.Tests
dotnet test src/NSwag/IBKR.Api.NSwag.Tests

# Run specific test
dotnet test --filter "FullyQualifiedName~StockQuoteTests"
```

## How It Works

The test infrastructure uses `ConfigurationBuilder` with this priority order:

1. **Environment variables** (highest priority)
2. **appsettings.json** configuration file
3. **Default values** / throw exception if required values missing

If `Testing:UseMockClient` is `true` (default), tests use mock data and no credentials are needed.

If `Testing:UseMockClient` is `false`, tests connect to the real IBKR API and credentials are **required**. Missing credentials will throw a clear exception:

```
InvalidOperationException: IBKR:ClientId not configured.
Set via appsettings.json or environment variable IBKR__ClientId
```

## Security Notes

- ✅ **DO** store PEM files outside the repository
- ✅ **DO** use environment variables for credentials
- ✅ **DO** use `.gitignore` to protect credential files (already configured)
- ❌ **DON'T** commit credentials to source control
- ❌ **DON'T** share your PEM files or credentials
- ❌ **DON'T** check in modified `appsettings.json` with credentials

## Troubleshooting

### "IBKR:ClientId not configured"

You're running tests with `UseMockClient=false` but haven't provided credentials. Either:
1. Set environment variables (see Option A above)
2. Update appsettings.json (see Option B above)
3. Or set `UseMockClient=true` to use mock data

### "PEM file not found"

The path in `ClientPemPath` doesn't exist. Check:
1. File path is correct and uses proper path separators (`\\` on Windows in JSON)
2. File actually exists at that location
3. You have read permissions for the file

### Tests fail with HTTP 401/403

Your credentials are configured but invalid. Verify:
1. ClientId, Credential, and ClientKeyId are correct
2. PEM file matches the ClientKeyId registered in IBKR portal
3. Your IBKR account has API access enabled

## Example: Quick Test Run

```powershell
# Windows PowerShell - Test with environment variables
$env:Testing__UseMockClient="false"
$env:IBKR__ClientId="TESTCONS"
$env:IBKR__Credential="myusername"
$env:IBKR__ClientKeyId="abc123"
$env:IBKR__ClientPemPath="C:\Users\Me\.ibkr\key.pem"

dotnet test src/Kiota/IBKR.Api.Kiota.Tests --filter "FullyQualifiedName~SearchStock_BySymbol_ReturnsContracts"
```
