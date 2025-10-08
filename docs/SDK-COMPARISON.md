# SDK Comparison: Clean API vs NSwag vs Kiota

This guide helps you choose between the three SDK layers by comparing their design philosophies, code patterns, and ideal use cases.

## TL;DR - Quick Decision Guide

| Your Situation | Choose This SDK |
|----------------|-----------------|
| **Production applications** | **Clean API** ⭐ (strongly-typed, error handling included) |
| **Quick prototypes** | **Clean API** ⭐ (minimal setup, comprehensive docs) |
| **Enterprise .NET apps** | **Clean API** ⭐ (DI-friendly, production-ready) |
| Need lower-level API control | **NSwag** 🔷 (direct API access) |
| Want IntelliSense-driven API discovery | **Kiota** 🔶 (fluent API surface) |
| Testing with service mocks is critical | **All** ✅ (all have full mock support) |
| Building microservices with minimal dependencies | **Clean API** ⭐ or **Kiota** 🔶 |
| SDK development/quirk discovery | **NSwag** 🔷 or **Kiota** 🔶 |

## Three-Layer Architecture

```
┌─────────────────────────────────────────────┐
│  Your Application                           │
│  ↓ Recommended: Use Clean API               │
├─────────────────────────────────────────────┤
│  ⭐ Clean API Layer                         │
│  • Strongly-typed models (DateTime, enums)  │
│  • Comprehensive error handling             │
│  • Built-in API quirk workarounds           │
│  • Thread-safe authentication               │
├─────────────────────────────────────────────┤
│  🔷 NSwag SDK / 🔶 Kiota SDK                │
│  • Generated from OpenAPI spec              │
│  • Direct API access                        │
│  • Manual workarounds needed                │
└─────────────────────────────────────────────┘
```

## Side-by-Side Code Comparison

### Example: Get Option Chain for AAPL

#### Clean API ⭐ (Recommended)
```csharp
// Strongly-typed, production-ready
var optionService = serviceProvider.GetRequiredService<IOptionService>();
var chain = await optionService.GetOptionChainAsync(
    "AAPL",
    DateTime.UtcNow,
    DateTime.UtcNow.AddDays(30));

// All fields are strongly typed
foreach (var contract in chain.Contracts)
{
    Console.WriteLine($"{contract.Symbol} {contract.Right} " +
                     $"Strike: {contract.Strike:C} " +         // decimal
                     $"Exp: {contract.Expiration:yyyy-MM-dd}"); // DateTime
}
```

**Characteristics:**
- ✅ Strongly-typed models (DateTime, decimal, enums)
- ✅ Comprehensive error handling
- ✅ API quirks handled automatically
- ✅ Production-ready from day one
- ✅ Excellent documentation

### Example: Get Unread Notification Count (Lower-Level SDKs)

#### NSwag SDK 🔷
```csharp
// Service interface injection
public class NotificationService
{
    private readonly IFyiService _fyiService;

    public NotificationService(IFyiService fyiService)
    {
        _fyiService = fyiService;
    }

    public async Task<int> GetUnreadCountAsync()
    {
        var response = await _fyiService.UnreadnumberAsync();
        return response.UnreadCount;
    }
}

// Dependency registration
services.AddTransient<IFyiService, FyiService>();
```

**Characteristics:**
- ✅ Interface-based (testable via DI)
- ✅ Familiar service pattern
- ⚠️ Requires understanding of which service interface to use

#### Kiota SDK 🔶
```csharp
// Fluent API with discoverability
public class NotificationService
{
    private readonly IBKRClient _client;

    public NotificationService(IRequestAdapter requestAdapter)
    {
        _client = new IBKRClient(requestAdapter);
    }

    public async Task<int> GetUnreadCountAsync()
    {
        var response = await _client.Fyi.Unreadnumber.GetAsync();
        return response.UnreadCount;
    }
}

// Dependency registration
services.AddSingleton<IRequestAdapter>(new HttpClientRequestAdapter(authProvider));
```

**Characteristics:**
- ✅ IntelliSense-driven discovery (`.Fyi.` autocompletes all FYI endpoints)
- ✅ Clear API structure follows REST hierarchy
- ⚠️ Requires IRequestAdapter setup

### Example: Making Authenticated Requests

#### NSwag SDK 🔷
```csharp
// HttpClient is configured once, services automatically use it
services.AddHttpClient<IFyiService, FyiService>(client =>
{
    client.BaseAddress = new Uri("https://api.ibkr.com");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
});

// Each service is independently injectable
services.AddTransient<IFyiService, FyiService>();
services.AddTransient<IGwService, GwService>();
services.AddTransient<IAccountService, AccountService>();
```

**Pros:**
- Each service can have independent HttpClient configuration
- Easy to mock individual services for testing
- Familiar to ASP.NET Core developers

**Cons:**
- More service registrations required
- Slightly more memory overhead (multiple HttpClient instances)

#### Kiota SDK 🔶
```csharp
// Single IRequestAdapter handles all requests
var authProvider = new ApiKeyAuthenticationProvider(
    "Authorization",
    $"Bearer {token}",
    ApiKeyAuthenticationProvider.KeyLocation.Header);

var requestAdapter = new HttpClientRequestAdapter(authProvider);
requestAdapter.BaseUrl = "https://api.ibkr.com";

// Single client provides access to all endpoints
var client = new IBKRClient(requestAdapter);

// All endpoints available through fluent API
await client.Fyi.Unreadnumber.GetAsync();
await client.Gw.Sessions.GetAsync();
await client.Account.Accounts.GetAsync();
```

**Pros:**
- Single configuration point for all requests
- Smaller memory footprint
- Fluent API makes endpoint structure clear

**Cons:**
- All endpoints share same authentication/configuration
- Less granular testability without custom IRequestAdapter

## Architecture Comparison

### NSwag Architecture 🔷

```
┌─────────────────────────────────────┐
│     Your Application (DI Container) │
└──────────┬──────────────────────────┘
           │
           │ Injects specific services
           │
    ┌──────▼────────┐  ┌──────────────┐  ┌──────────────┐
    │ IFyiService   │  │ IGwService   │  │ IAccountSvc  │
    │               │  │              │  │              │
    │ - Unread      │  │ - Sessions   │  │ - Accounts   │
    │ - Settings    │  │ - Tasks      │  │ - Summary    │
    │ - Notify      │  │ - Ping       │  │ - PnL        │
    └───────────────┘  └──────────────┘  └──────────────┘
```

**Key Points:**
- Service-per-API-area design
- Each service is independently injectable
- Interface-based testing is straightforward

### Kiota Architecture 🔶

```
┌─────────────────────────────────────┐
│     Your Application (DI Container) │
└──────────┬──────────────────────────┘
           │
           │ Injects IRequestAdapter
           │
    ┌──────▼─────────────────────────┐
    │      IBKRClient                │
    │                                │
    │  ┌────────────────────────────┤
    │  │ .Fyi                       │
    │  │   └─ .Unreadnumber         │
    │  │   └─ .Settings             │
    │  │   └─ .Notifications        │
    │  │                            │
    │  │ .Gw                        │
    │  │   └─ .Sessions             │
    │  │   └─ .Tasks                │
    │  │                            │
    │  │ .Account                   │
    │  │   └─ .Accounts             │
    │  │   └─ .Summary              │
    │  └─────────────────────────────┤
    └────────────────────────────────┘
```

**Key Points:**
- Single client with hierarchical API structure
- Request builders provide fluent interface
- Testing requires mocking IRequestAdapter

## Performance & Dependencies

### Package Size Comparison

| Package | NSwag | Kiota |
|---------|-------|-------|
| Contract | ~200 KB | ~150 KB |
| Client | ~300 KB | ~200 KB |
| **Total** | **~500 KB** | **~350 KB** |
| Dependencies | 8 packages | 5 packages |

**Winner:** Kiota 🔶 (30% smaller footprint)

### Runtime Performance

Both SDKs have similar runtime performance characteristics:
- Both use HttpClient under the hood
- Serialization: NSwag uses Newtonsoft.Json, Kiota uses System.Text.Json
- Memory: Kiota has slight edge due to fewer service instances

**Winner:** Tie ⚖️ (negligible difference in real-world usage)

### Cold Start Time

For applications where cold start matters (Azure Functions, AWS Lambda):
- **NSwag**: ~50ms additional startup time (DI container registrations)
- **Kiota**: ~30ms additional startup time (single adapter initialization)

**Winner:** Kiota 🔶 (marginally faster cold starts)

## Testing Comparison

### Unit Testing with Mocks

#### NSwag Testing 🔷
```csharp
public class NotificationServiceTests
{
    [Fact]
    public async Task GetUnreadCount_ReturnsCorrectNumber()
    {
        // Arrange - Mock specific service
        var mockFyiService = new MockFyiService();
        mockFyiService.SetupUnreadnumberAsync(new Response { UnreadCount = 5 });

        var service = new NotificationService(mockFyiService);

        // Act
        var count = await service.GetUnreadCountAsync();

        // Assert
        Assert.Equal(5, count);
    }
}
```

**Pros:**
- Mock only what you need
- Very granular test isolation
- Easy to understand test setup

#### Kiota Testing 🔶
```csharp
public class NotificationServiceTests
{
    [Fact]
    public async Task GetUnreadCount_ReturnsCorrectNumber()
    {
        // Arrange - Mock request adapter
        var mockAdapter = new MockRequestAdapter();
        mockAdapter.SetCannedResponse(
            "/fyi/unreadnumber",
            new Response { UnreadCount = 5 }
        );

        var service = new NotificationService(mockAdapter);

        // Act
        var count = await service.GetUnreadCountAsync();

        // Assert
        Assert.Equal(5, count);
    }
}
```

**Pros:**
- Single mock adapter for all endpoints
- Tests reflect actual API paths
- Good for integration-style tests

**Winner:** Depends on test style preference

### Configuration-Based Testing

Both SDKs support configuration-based switching between mock and real implementations via `appsettings.json`:

```json
{
  "Testing": {
    "UseMockClient": true  // false for integration tests
  }
}
```

This allows:
- Fast unit tests in CI/CD (mocks)
- Integration tests locally (real API)
- Same test code for both scenarios

## Migration Between SDKs

### NSwag → Kiota

**Changes Required:**
1. Replace service interfaces with IBKRClient
2. Change from constructor injection of services to IRequestAdapter
3. Update method calls from `service.MethodAsync()` to `client.Area.Method.GetAsync()`

**Example:**
```csharp
// Before (NSwag)
public class Service
{
    public Service(IFyiService fyi, IGwService gw) { }
    var count = await _fyi.UnreadnumberAsync();
}

// After (Kiota)
public class Service
{
    public Service(IRequestAdapter adapter)
    {
        _client = new IBKRClient(adapter);
    }
    var count = await _client.Fyi.Unreadnumber.GetAsync();
}
```

### Kiota → NSwag

**Changes Required:**
1. Replace IBKRClient with specific service interfaces
2. Register individual services in DI container
3. Update method calls to match service interface methods

## Pros & Cons Summary

### Clean API ⭐

**Pros:**
✅ Strongly-typed models (DateTime, decimal, enums)
✅ Comprehensive error handling built-in
✅ All API quirks handled automatically
✅ Thread-safe authentication
✅ Production-ready from day one
✅ Excellent documentation and examples
✅ DI-friendly design
✅ High-quality test suite with comprehensive logging

**Cons:**
⚠️ Currently covers option-related endpoints only (expanding)
⚠️ Builds on NSwag (includes NSwag dependencies)

**Best For:** Production applications, quick prototypes, developers who want a polished experience

### NSwag SDK 🔷

**Pros:**
✅ Familiar service-oriented pattern
✅ Interface-based design (great for testing)
✅ Works seamlessly with ASP.NET Core DI
✅ Independent service configuration
✅ Each service can have different HttpClient settings
✅ Direct API access for all endpoints

**Cons:**
⚠️ Larger dependency footprint
⚠️ More DI registrations required
⚠️ API structure less discoverable (which interface has which method?)
⚠️ Multiple HttpClient instances (slightly more memory)
⚠️ Manual workarounds for API quirks

**Best For:** Lower-level control, SDK development, quirk discovery

### Kiota SDK 🔶

**Pros:**
✅ Fluent, discoverable API surface
✅ Smaller package size
✅ Single configuration point
✅ Better IntelliSense experience
✅ Follows REST API hierarchy clearly
✅ Microsoft-backed, modern tooling

**Cons:**
⚠️ Less familiar to traditional .NET developers
⚠️ Requires understanding IRequestAdapter
⚠️ All endpoints share same configuration
⚠️ Testing requires mocking at adapter level
⚠️ Manual workarounds for API quirks

**Best For:** API discovery, modern fluent patterns, minimal footprint

## Real-World Use Case Recommendations

### Use Clean API ⭐ When:

1. **Building Production Applications**
   - Need strongly-typed models and comprehensive error handling
   - Want API quirks handled automatically
   - Require thread-safe authentication out of the box

2. **Rapid Prototyping**
   - Want to get started quickly with minimal setup
   - Need good documentation and examples
   - Don't want to deal with API quirks

3. **Enterprise .NET Applications**
   - Using dependency injection extensively
   - Need production-ready abstractions
   - Want high-quality test coverage

**Note:** Clean API currently covers option-related endpoints. For other endpoints, use NSwag or Kiota (we're expanding coverage over time).

### Use NSwag 🔷 When:

1. **Enterprise ASP.NET Core Applications**
   - Already using service-oriented architecture
   - Heavy DI container usage
   - Need granular service mocking

2. **Legacy System Integration**
   - Migrating from older REST client patterns
   - Team familiar with service interfaces
   - Need backward compatibility with existing code

3. **Microservices with Independent Services**
   - Each service needs different authentication
   - Different retry policies per service
   - Service-specific circuit breakers

### Use Kiota 🔶 When:

1. **Modern .NET Applications**
   - Building greenfield projects
   - Want modern, fluent API patterns
   - Minimize dependency footprint matters

2. **API Exploratory Development**
   - Learning the IBKR API
   - Need IntelliSense to discover endpoints
   - Want clear API structure visualization

3. **Azure Functions / AWS Lambda**
   - Cold start time is critical
   - Memory footprint matters
   - Simple, single-purpose functions

4. **Console Applications / Scripts**
   - Quick tooling and automation
   - Don't need complex DI
   - Want straightforward API access

## Can I Use Multiple SDKs?

**Yes!** All three SDK layers can coexist in the same solution:

```xml
<ItemGroup>
  <!-- Clean API for option trading -->
  <PackageReference Include="IBKR.Api.Contract" Version="1.0.0" />
  <PackageReference Include="IBKR.Api.Client" Version="1.0.0" />
  <PackageReference Include="IBKR.Api.Authentication" Version="1.0.0" />

  <!-- NSwag for other endpoints not yet in Clean API -->
  <PackageReference Include="IBKR.Api.NSwag.Contract" Version="1.0.0" />
  <PackageReference Include="IBKR.Api.NSwag.Client" Version="1.0.0" />
</ItemGroup>
```

**Why would you do this?**
- Use Clean API for supported endpoints (options)
- Use NSwag/Kiota for endpoints not yet in Clean API
- Gradual migration as Clean API coverage expands
- Different teams prefer different patterns

⚠️ **Caution:** Clean API already includes NSwag dependencies, so combining Clean API + NSwag doesn't add much overhead.

## Conclusion

All three SDK layers are **production-ready** and **fully supported**. Your choice comes down to:

| Priority | Choose |
|----------|--------|
| **Production-ready abstractions** | **Clean API** ⭐ |
| **Strongly-typed models** | **Clean API** ⭐ |
| **Quick setup** | **Clean API** ⭐ |
| Lower-level API control | NSwag 🔷 |
| API discoverability | Kiota 🔶 |
| Smallest package size | Kiota 🔶 |
| SDK development | NSwag 🔷 or Kiota 🔶 |

**Recommendation for most developers:** Start with **Clean API** ⭐ for the best experience. Use NSwag or Kiota for endpoints not yet covered by the Clean API.

---

**Next Steps:**
- [Getting Started Guide](GETTING-STARTED.md) - Install and make your first API call
- [Clean API Guide](CLEAN-API.md) - Production-ready abstraction layer (recommended)
- [NSwag SDK Guide](NSWAG-SDK.md) - Deep dive into service-oriented architecture
- [Kiota SDK Guide](KIOTA-SDK.md) - Deep dive into fluent API architecture
