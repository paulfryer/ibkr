# Authentication Guide

This guide explains how to authenticate with the IBKR API using OAuth2 with JWT signing. The authentication infrastructure supports both SDKs and includes mock authentication for testing.

## Overview

IBKR uses a **3-step OAuth2 flow** with JWT (JSON Web Token) signing:

```
1. Request Access Token
   ├─ Create JWT client assertion (signed with RSA private key)
   ├─ POST to /oauth2/api/v1/token
   └─ Receive access_token

2. Request Bearer Token (SSO Session)
   ├─ Create signed JWT request (includes IP, credential)
   ├─ POST to /gw/api/v1/sso-sessions with access_token
   └─ Receive bearer_token

3. Initialize Brokerage Session
   ├─ POST to /iserver/auth/ssodh/init with bearer_token
   └─ Session ready for API calls

All subsequent API calls use the bearer_token
```

## Prerequisites

Before you can authenticate, you need:

### 1. IBKR OAuth2 Credentials

Register your application in the [IBKR API Portal](https://api.ibkr.com):

1. Go to https://api.ibkr.com
2. Create a new OAuth2 application
3. Note the following values:
   - **Client ID** (e.g., `TESTCONS`)
   - **Client Key ID** (e.g., `kid_12345`)
   - **Download the RSA private key** (.pem file)

### 2. RSA Private Key

- Store the `.pem` file securely (NOT in source control)
- Typical location: `~/.ibkr/private.pem`
- Required format: PEM with RSA private key (3072-bit)

### 3. IBKR Account Credentials

- **Username**: Your IBKR account username
- Used in Step 2 of the OAuth2 flow

## Architecture

### Shared Authentication Library

`IBKR.Sdk.Authentication` provides core OAuth2 functionality:

```
IBKR.Sdk.Authentication/
├── IBKRAuthenticationOptions.cs      # Configuration
├── IIBKRAuthenticationProvider.cs    # Interface
├── IBKRAuthenticationProvider.cs     # Real OAuth2 implementation
├── MockAuthenticationProvider.cs     # Testing mock
├── JwtSigner.cs                      # RS256 JWT signing
└── TokenCache.cs                     # 5-minute token cache
```

### SDK-Specific Integration

**NSwag**: `IBKR.Api.NSwag.Authentication`
- Uses `HttpMessageHandler` to intercept requests
- Automatically adds `Authorization: Bearer {token}` header

**Kiota**: `IBKR.Api.Kiota.Authentication`
- Implements `IAuthenticationProvider` (Microsoft.Kiota pattern)
- Integrates with Kiota's request pipeline

## Configuration

### appsettings.json

```json
{
  "IBKR": {
    "ClientId": "TESTCONS",
    "Credential": "your-ibkr-username",
    "ClientKeyId": "kid_12345",
    "ClientPemPath": "C:\\path\\to\\private.pem",
    "BaseUrl": "https://api.ibkr.com"
  },
  "Testing": {
    "UseMockClient": false,
    "UseRealAuthentication": true
  }
}
```

### Environment Variables (Recommended)

For production, use environment variables instead:

```bash
# Windows
set IBKR__ClientId=TESTCONS
set IBKR__Credential=your-username
set IBKR__ClientKeyId=kid_12345
set IBKR__ClientPemPath=C:\path\to\private.pem

# Linux/Mac
export IBKR__ClientId="TESTCONS"
export IBKR__Credential="your-username"
export IBKR__ClientKeyId="kid_12345"
export IBKR__ClientPemPath="/path/to/private.pem"
```

### .env File (Development)

Create `.env` file in your project root (gitignored):

```bash
IBKR__ClientId=TESTCONS
IBKR__Credential=your-username
IBKR__ClientKeyId=kid_12345
IBKR__ClientPemPath=/Users/you/.ibkr/private.pem
```

## Usage

### NSwag SDK with Authentication

#### Setup in Program.cs

```csharp
using IBKR.Sdk.Authentication;
using IBKR.Api.NSwag.Authentication;
using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Load authentication options from configuration
var authOptions = new IBKRAuthenticationOptions
{
    ClientId = builder.Configuration["IBKR:ClientId"],
    Credential = builder.Configuration["IBKR:Credential"],
    ClientKeyId = builder.Configuration["IBKR:ClientKeyId"],
    ClientPemPath = builder.Configuration["IBKR:ClientPemPath"],
    BaseUrl = builder.Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
};

// Register authenticated service
builder.Services.AddIBKRAuthenticatedClient<IFyiService, FyiService>(
    authOptions,
    client =>
    {
        client.BaseAddress = new Uri(authOptions.BaseUrl);
        client.Timeout = TimeSpan.FromSeconds(30);
    }
);

// Add more services as needed
// builder.Services.AddIBKRAuthenticatedClient<IGwService, GwService>(authOptions);
```

#### Using in Controllers/Services

```csharp
public class NotificationController : ControllerBase
{
    private readonly IFyiService _fyiService;

    public NotificationController(IFyiService fyiService)
    {
        _fyiService = fyiService;
    }

    [HttpGet("unread-count")]
    public async Task<IActionResult> GetUnreadCount()
    {
        // Authentication is automatic - no need to manage tokens
        var response = await _fyiService.UnreadnumberAsync();
        return Ok(new { unreadCount = response.UnreadCount });
    }
}
```

### Kiota SDK with Authentication

#### Setup in Program.cs

```csharp
using IBKR.Sdk.Authentication;
using IBKR.Api.Kiota.Authentication;
using IBKR.Api.Kiota.Client;

var builder = WebApplication.CreateBuilder(args);

// Load authentication options from configuration
var authOptions = new IBKRAuthenticationOptions
{
    ClientId = builder.Configuration["IBKR:ClientId"],
    Credential = builder.Configuration["IBKR:Credential"],
    ClientKeyId = builder.Configuration["IBKR:ClientKeyId"],
    ClientPemPath = builder.Configuration["IBKR:ClientPemPath"],
    BaseUrl = builder.Configuration["IBKR:BaseUrl"] ?? "https://api.ibkr.com"
};

// Register authenticated Kiota client
builder.Services.AddIBKRAuthenticatedKiotaClient(authOptions);
```

#### Using in Controllers/Services

```csharp
public class NotificationService
{
    private readonly IBKRClient _client;

    public NotificationService(IBKRClient client)
    {
        _client = client;
    }

    public async Task<int> GetUnreadCountAsync()
    {
        // Authentication is automatic - fluent API
        var response = await _client.Fyi.Unreadnumber.GetAsync();
        return response?.UnreadCount ?? 0;
    }
}
```

## Testing with Mock Authentication

For unit tests, use `MockAuthenticationProvider` instead of real credentials:

### NSwag Tests

```csharp
// TestFixture.cs
var useMockClient = Configuration.GetValue<bool>("Testing:UseMockClient", true);
var useRealAuthentication = Configuration.GetValue<bool>("Testing:UseRealAuthentication", false);

if (useMockClient)
{
    // Use mock services AND mock authentication
    services.AddSingleton<IIBKRAuthenticationProvider>(new MockAuthenticationProvider());
    services.AddTransient<IFyiService, MockFyiService>();
}
else if (useRealAuthentication)
{
    // Use real services WITH real authentication
    var authOptions = LoadAuthOptionsFromConfig();
    services.AddIBKRAuthenticatedClient<IFyiService, FyiService>(authOptions);
}
```

### Kiota Tests

```csharp
// TestFixture.cs
if (useMockClient)
{
    // Use mock request adapter (no authentication)
    services.AddSingleton<IRequestAdapter>(sp => new MockRequestAdapter());
}
else if (useRealAuthentication)
{
    // Use real request adapter WITH authentication
    var authOptions = LoadAuthOptionsFromConfig();
    services.AddIBKRAuthenticatedKiotaClient(authOptions);
}
```

### Test Configuration

```json
// appsettings.test.json (CI/CD - no real auth)
{
  "Testing": {
    "UseMockClient": true,
    "UseRealAuthentication": false
  }
}

// appsettings.development.json (Local - optional real auth)
{
  "Testing": {
    "UseMockClient": false,
    "UseRealAuthentication": true
  },
  "IBKR": {
    "ClientId": "TESTCONS",
    "Credential": "your-username",
    "ClientKeyId": "kid_12345",
    "ClientPemPath": "/path/to/private.pem"
  }
}
```

## Token Management

### Automatic Token Caching

The authentication provider caches bearer tokens for **5 minutes**:

- No need to manually manage tokens
- Automatic refresh when expired
- Thread-safe caching

### Manual Token Refresh

If you need to force a token refresh:

```csharp
var authProvider = serviceProvider.GetRequiredService<IIBKRAuthenticationProvider>();
await authProvider.RefreshAsync();
```

## Security Best Practices

### 1. Never Commit Credentials

**Add to `.gitignore`:**

```gitignore
# IBKR credentials
*.pem
appsettings.development.json
.env
```

### 2. Secure PEM File Storage

```bash
# Linux/Mac - Restrict permissions
chmod 600 ~/.ibkr/private.pem

# Windows - Restrict NTFS permissions
icacls C:\path\to\private.pem /inheritance:r /grant:r "%USERNAME%:(R)"
```

### 3. Use Environment Variables in Production

Don't store credentials in `appsettings.json` for production:

```csharp
// Program.cs
builder.Configuration.AddEnvironmentVariables("IBKR_");

// Deploy with environment variables:
// IBKR_ClientId, IBKR_Credential, etc.
```

### 4. Rotate Keys Regularly

- Generate new RSA key pairs periodically
- Update in IBKR portal
- Deploy new keys to production

### 5. Limit Token Lifetime

The authentication provider uses a 5-minute token cache. You can configure this:

```csharp
var authOptions = new IBKRAuthenticationOptions
{
    // ... other options
    TokenCacheMinutes = 3  // Shorter lifetime for sensitive environments
};
```

## Troubleshooting

### "ClientId is required"

**Cause:** Missing configuration

**Solution:** Ensure all required configuration values are set:

```json
{
  "IBKR": {
    "ClientId": "TESTCONS",
    "Credential": "username",
    "ClientKeyId": "kid_12345",
    "ClientPemPath": "/path/to/private.pem"
  }
}
```

### "PEM file not found"

**Cause:** Invalid path to private key

**Solution:** Use absolute path and verify file exists:

```bash
# Check file exists
ls /path/to/private.pem

# Update configuration with correct path
```

### "Failed to obtain access token"

**Possible Causes:**
- Invalid Client ID
- Invalid Client Key ID
- Invalid JWT signature (wrong PEM file)

**Debug:**

```csharp
try
{
    var token = await authProvider.GetBearerTokenAsync();
}
catch (HttpRequestException ex)
{
    // Check response status code and message
    Console.WriteLine($"HTTP Error: {ex.Message}");
}
```

### "Failed to obtain bearer token"

**Possible Causes:**
- Invalid credential (username)
- Incorrect IP address in JWT
- Access token expired

**Debug:** Check that `api.ipify.org` is accessible for IP detection

### "Session not authenticated or connected"

**Cause:** Session initialization failed

**Solution:** Ensure bearer token is valid and account is active

### Token Cache Not Working

**Cause:** Multiple instances of authentication provider

**Solution:** Register as **singleton**:

```csharp
// Correct - singleton
services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
    new IBKRAuthenticationProvider(authOptions));

// Wrong - transient creates new instance every time
services.AddTransient<IIBKRAuthenticationProvider>(sp =>
    new IBKRAuthenticationProvider(authOptions));
```

## Advanced Scenarios

### Custom Token Cache

Implement your own caching strategy:

```csharp
public class RedisAuthenticationProvider : IIBKRAuthenticationProvider
{
    private readonly IBKRAuthenticationProvider _innerProvider;
    private readonly IDistributedCache _cache;

    public async Task<string> GetBearerTokenAsync(CancellationToken ct = default)
    {
        var cached = await _cache.GetStringAsync("ibkr_token", ct);
        if (cached != null) return cached;

        var token = await _innerProvider.GetBearerTokenAsync(ct);
        await _cache.SetStringAsync("ibkr_token", token,
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) }, ct);

        return token;
    }
}
```

### Multiple IBKR Accounts

Register multiple authentication providers:

```csharp
services.AddSingleton<IIBKRAuthenticationProvider>(sp =>
    new IBKRAuthenticationProvider(account1Options));

services.AddSingleton("Account2Auth", sp =>
    new IBKRAuthenticationProvider(account2Options));
```

### Custom IP Detection

Override default IP detection (uses `api.ipify.org`):

```csharp
// Extend IBKRAuthenticationProvider
public class CustomIPAuthProvider : IBKRAuthenticationProvider
{
    public CustomIPAuthProvider(IBKRAuthenticationOptions options) : base(options)
    {
    }

    // Override GetPublicIpAddressAsync method
    protected override Task<string> GetPublicIpAddressAsync(CancellationToken ct)
    {
        return Task.FromResult("203.0.113.42"); // Your static IP
    }
}
```

## API Reference

### IBKRAuthenticationOptions

| Property | Type | Required | Description |
|----------|------|----------|-------------|
| `ClientId` | `string` | Yes | OAuth2 Client ID from IBKR portal |
| `Credential` | `string` | Yes | IBKR account username |
| `ClientKeyId` | `string` | Yes | OAuth2 Key Identifier (kid) |
| `ClientPemPath` | `string` | Yes | Absolute path to RSA private key PEM file |
| `BaseUrl` | `string` | No | API base URL (default: https://api.ibkr.com) |
| `TokenCacheMinutes` | `int` | No | Token cache lifetime (default: 5 minutes) |

### IIBKRAuthenticationProvider

```csharp
Task<string> GetBearerTokenAsync(CancellationToken cancellationToken = default);
Task<bool> InitializeSessionAsync(CancellationToken cancellationToken = default);
Task RefreshAsync(CancellationToken cancellationToken = default);
```

### Extension Methods

**NSwag:**

```csharp
IHttpClientBuilder AddIBKRAuthenticatedClient<TInterface, TImplementation>(
    this IServiceCollection services,
    IBKRAuthenticationOptions options,
    Action<HttpClient>? configureClient = null)
```

**Kiota:**

```csharp
IServiceCollection AddIBKRAuthenticatedKiotaClient(
    this IServiceCollection services,
    IBKRAuthenticationOptions options,
    Action<HttpClient>? configureClient = null,
    string? baseUrl = null)
```

## Next Steps

- **[NSwag SDK Guide](NSWAG-SDK.md)** - Using authentication with NSwag
- **[Kiota SDK Guide](KIOTA-SDK.md)** - Using authentication with Kiota
- **[Testing Guide](TESTING.md)** - Testing with mock authentication
- **[Getting Started](GETTING-STARTED.md)** - Complete setup walkthrough

---

**Questions?** Open an issue at https://github.com/paulfryer/ibkr/issues
