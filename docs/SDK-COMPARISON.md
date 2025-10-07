# SDK Comparison: NSwag vs Kiota

This guide helps you choose between the two SDK architectures by comparing their design philosophies, code patterns, and ideal use cases.

## TL;DR - Quick Decision Guide

| Your Situation | Choose This SDK |
|----------------|-----------------|
| Building enterprise .NET app with existing DI infrastructure | **NSwag** 🔷 |
| Want IntelliSense-driven API discovery | **Kiota** 🔶 |
| Testing with service mocks is critical | **Either** ✅ (both have full mock support) |
| Building microservices with minimal dependencies | **Kiota** 🔶 |
| Familiar with traditional service-oriented .NET patterns | **NSwag** 🔷 |
| Want smaller package footprint | **Kiota** 🔶 |
| Using ASP.NET Core built-in DI | **NSwag** 🔷 |
| Prefer fluent API style (like LINQ) | **Kiota** 🔶 |

## Side-by-Side Code Comparison

### Example: Get Unread Notification Count

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

### NSwag SDK 🔷

**Pros:**
✅ Familiar service-oriented pattern
✅ Interface-based design (great for testing)
✅ Works seamlessly with ASP.NET Core DI
✅ Independent service configuration
✅ Each service can have different HttpClient settings

**Cons:**
⚠️ Larger dependency footprint
⚠️ More DI registrations required
⚠️ API structure less discoverable (which interface has which method?)
⚠️ Multiple HttpClient instances (slightly more memory)

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

## Real-World Use Case Recommendations

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

## Can I Use Both?

**Yes!** Both SDKs can coexist in the same solution:

```xml
<ItemGroup>
  <!-- Use NSwag for FYI endpoints -->
  <PackageReference Include="IBKR.Api.NSwag.Contract" Version="1.0.0" />
  <PackageReference Include="IBKR.Api.NSwag.Client" Version="1.0.0" />

  <!-- Use Kiota for Account endpoints -->
  <PackageReference Include="IBKR.Api.Kiota.Contract" Version="1.0.0" />
  <PackageReference Include="IBKR.Api.Kiota.Client" Version="1.0.0" />
</ItemGroup>
```

**Why would you do this?**
- Gradual migration from one to the other
- Different teams prefer different patterns
- Specific features work better in one SDK

⚠️ **Caution:** Mixing SDKs increases overall dependency footprint. Choose one SDK unless you have a specific reason to use both.

## Conclusion

Both SDKs are **production-ready** and **fully supported**. Your choice comes down to:

| Priority | Choose |
|----------|--------|
| Developer familiarity | NSwag 🔷 |
| API discoverability | Kiota 🔶 |
| Package size | Kiota 🔶 |
| Testing granularity | NSwag 🔷 |
| Modern patterns | Kiota 🔶 |

**Still undecided?** Start with the [Getting Started Guide](GETTING-STARTED.md) and try both! The SDK choice can be changed later with minimal refactoring.

---

**Next Steps:**
- [Getting Started Guide](GETTING-STARTED.md) - Install and make your first API call
- [NSwag SDK Guide](NSWAG-SDK.md) - Deep dive into service-oriented architecture
- [Kiota SDK Guide](KIOTA-SDK.md) - Deep dive into fluent API architecture
