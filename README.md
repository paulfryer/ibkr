# IBKR Trading API - C# SDK

A professional, clean C# SDK for the Interactive Brokers (IBKR) Web Trading API built with .NET 8.

## 🏗️ Architecture

### Project Structure

```
IBKR.TradingApi.sln
├── src/
│   ├── IBKR.Api.Client/           # Main SDK Library (.NET 8)
│   └── IBKR.Api.Client.Mock/      # Mock Implementation for Testing
└── tests/
    └── IBKR.Api.Client.Tests/     # Unit Tests (xUnit, 20 tests)
```

### Core Features

✅ **Implemented:**
- Clean architecture with separation of concerns
- Comprehensive model classes for all API domains
- Custom exception hierarchy for error handling
- Token bucket rate limiter (50 req/sec default)
- Configuration options with validation
- Full async/await support
- Nullable reference types enabled
- XML documentation for all public APIs

## 📦 NuGet Dependencies

**Main Library:**
- Microsoft.Extensions.DependencyInjection.Abstractions 8.0.0
- Microsoft.Extensions.Http 8.0.0
- Microsoft.Extensions.Options 8.0.0
- Polly 8.4.2 (Retry policies)
- System.Text.Json 8.0.5

**Mock Project:**
- No external dependencies (references main library only)

**Test Project:**
- xUnit 2.5.3
- FluentAssertions 6.12.0

## 🎯 Implemented Components

### Enums (`Models/Enums/`)
- `OrderSide` - BUY, SELL
- `OrderType` - MKT, LMT, STP, STP_LMT, REL, TRAIL, MIDPRICE
- `TimeInForce` - DAY, GTC, IOC, FOK, OPG, DTC
- `SecurityType` - STK, OPT, FUT, FOP, IND, CASH, BOND, FUND
- `OrderStatusEnum` - Order status states
- `OptionRight` - Call (C) or Put (P)

### Exceptions (`Exceptions/`)
- `IBKRApiException` - Base exception
- `RateLimitExceededException` - 429 errors with retry-after
- `AuthenticationException` - 401 errors
- `SessionExpiredException` - Expired session handling
- `OrderException` - Order-specific errors

### Models

#### Common (`Models/Common/`)
- `ApiResponse<T>` - Generic response wrapper
- `PagedResult<T>` - Paged result sets

#### Authentication (`Models/Authentication/`)
- `AuthStatusResponse` - Authentication status
- `SsoInitResponse` - SSO initialization
- `TickleResponse` - Session keep-alive
- `ServerInfo` - Server information

#### Accounts (`Models/Accounts/`)
- `TradingAccountsResponse` - List of trading accounts
- `AccountInfo` - Detailed account information
- `AccountParent` - Parent account info for FA/IBroker

#### Portfolio (`Models/Portfolio/`)
- `LedgerEntry` - Cash balances by currency
- `SummaryValue` - Portfolio summary values

#### Orders (`Models/Orders/`)
- `OrderRequest` - Place/modify order request
- `OrderResponse` - Order placement response
- `OrderReplyMessage` - Confirmation messages
- `Order` - Full order details
- `OrderStatus` - Detailed order status

#### Market Data (`Models/MarketData/`)
- `MarketDataSnapshot` - Real-time quotes
- `HistoricalData` - Historical bars
- `BarData` - OHLCV bar data

#### Instruments (`Models/Instruments/`)
- `SecurityDefinition` - Security search results
- `SecurityInfo` - Detailed security information
- `SecuritySection` - Contract details

### Infrastructure

#### Core (`Core/`)
- `IBKRClientOptions` - Configuration with validation
  - Base URL configuration
  - Rate limiting settings
  - Retry policy settings
  - Timeout configuration
  - SSL validation
  - Logging options

#### Rate Limiter (`Infrastructure/RateLimiter/`)
- `IRateLimiter` - Rate limiter interface
- `TokenBucketRateLimiter` - Thread-safe token bucket implementation
  - Configurable requests per second
  - Burst support
  - Async waiting
  - Try-acquire for non-blocking checks

## 🚀 Next Steps to Complete SDK

### 1. HTTP Infrastructure
- [ ] `IBKRHttpClient` - Core HTTP client wrapper
- [ ] `AuthenticationHandler` - DelegatingHandler for auth
- [ ] `RateLimitHandler` - DelegatingHandler for rate limiting
- [ ] `LoggingHandler` - DelegatingHandler for logging

### 2. Retry Policy
- [ ] Exponential backoff with Polly
- [ ] Transient error detection
- [ ] Configurable retry attempts

### 3. API Services
- [ ] `IAuthenticationApiService` + Implementation
- [ ] `IAccountApiService` + Implementation
- [ ] `IPortfolioApiService` + Implementation
- [ ] `IMarketDataApiService` + Implementation
- [ ] `IOrderApiService` + Implementation (most complex - handle confirmations)
- [ ] `IInstrumentApiService` + Implementation
- [ ] `IScannerApiService` + Implementation
- [ ] `INotificationApiService` + Implementation

### 4. Main Client
- [ ] `IIBKRClient` - Main client interface
- [ ] `IBKRClient` - Main client implementation
  - Aggregate all services
  - Session management
  - Lifecycle management

### 5. Dependency Injection
- [ ] `ServiceCollectionExtensions` - AddIBKRClient() method
- [ ] HttpClientFactory integration
- [ ] Options pattern configuration

### 6. Testing ✅ COMPLETE
- [x] **Implementation-Agnostic Test Architecture** - Tests use DI, zero knowledge of implementation
- [x] **Mock Implementation Project** - Real in-memory implementation (not Moq)
- [x] **Test Infrastructure** - xUnit fixtures with configuration switching
- [x] **20 Passing Tests** covering:
  - Stock search and contract lookup
  - Option chain retrieval and filtering
  - Strike price validation
  - End-to-end MSFT option scenarios
- [x] **Environment-Based Switching** - `USE_REAL_IBKR_API=true` to switch to real HTTP client
- [ ] HTTP implementation of IInstrumentApiService (when ready)

## 📖 Usage Example (When Complete)

```csharp
// Configure with DI
services.AddIBKRClient(options =>
{
    options.BaseUrl = "https://api.ibkr.com/v1/api";
    options.BearerToken = "your-token";
    options.RateLimitPerSecond = 50;
});

// Inject and use
public class TradingService
{
    private readonly IIBKRClient _client;

    public TradingService(IIBKRClient client)
    {
        _client = client;
    }

    public async Task PlaceOrderAsync()
    {
        // Check auth status
        var authStatus = await _client.Authentication.GetAuthStatusAsync();

        // Get accounts
        var accounts = await _client.Accounts.GetTradingAccountsAsync();

        // Place order
        var order = new OrderRequest
        {
            Conid = 265598, // AAPL
            Side = OrderSide.BUY,
            OrderType = OrderType.LMT,
            Price = 150.00m,
            Quantity = 100,
            Tif = TimeInForce.DAY
        };

        var result = await _client.Orders.PlaceOrderAsync(
            accounts.SelectedAccount!,
            order
        );
    }
}
```

## 🏗️ Build Status

```bash
# Restore packages
dotnet restore

# Build
dotnet build

# Run tests
dotnet test

# Run tests with real API (requires credentials)
USE_REAL_IBKR_API=true dotnet test
```

## 📝 Code Quality

- **Target Framework**: .NET 8.0
- **Language Version**: Latest C#
- **Nullable**: Enabled
- **Documentation**: XML comments on all public APIs
- **Style**: EditorConfig (recommended)

## 🧪 Testing Architecture

This project uses a **pure dependency injection** approach where tests have **ZERO knowledge** of implementation details.

### Key Principles

1. **Tests depend only on interfaces** (`IInstrumentApiService`)
2. **No Moq in tests** - Tests receive services via constructor injection
3. **Single switch controls implementation** - Environment variable or configuration
4. **Same tests run against mock or real API** - No code changes needed

### Project Layout

```
src/IBKR.Api.Client.Mock/
├── Data/MsftTestData.cs                    # Realistic test data
├── Services/MockInstrumentApiService.cs    # Real in-memory implementation
└── Services/MockInstrumentApiServiceBuilder.cs  # Fluent configuration API

tests/IBKR.Api.Client.Tests/
├── Infrastructure/
│   ├── TestConfiguration.cs                # Reads environment config
│   └── InstrumentServiceFixture.cs         # xUnit fixture for DI
├── Services/                               # Interface contract tests
└── Scenarios/                              # End-to-end workflow tests
```

### How It Works

**Test receives service via DI - doesn't know if mock or real:**

```csharp
public class MyTests : IClassFixture<InstrumentServiceFixture>
{
    private readonly IInstrumentApiService _service;  // Could be mock or real!

    public MyTests(InstrumentServiceFixture fixture)
    {
        _service = fixture.Service;  // Injected by xUnit
    }

    [Fact]
    public async Task CanSearchForMsft()
    {
        var results = await _service.SearchStocksAsync("MSFT");
        results.Should().ContainKey("MSFT");
    }
}
```

**Fixture determines implementation:**

```csharp
public class InstrumentServiceFixture : IDisposable
{
    public IInstrumentApiService Service { get; }

    public InstrumentServiceFixture()
    {
        var config = TestConfiguration.LoadFromEnvironment();

        if (config.UseRealApi)
            Service = new RealHttpService();  // Future
        else
            Service = MockInstrumentApiServiceBuilder.CreateDefault().Build();
    }
}
```

### Running Tests

```bash
# Default: Use mock implementation
dotnet test
# Output: 20 tests passed in ~20ms

# Switch to real API (when HTTP client is implemented)
export USE_REAL_IBKR_API=true
export IBKR_API_BASE_URL=https://localhost:5000/v1/api
export IBKR_AUTH_TOKEN=your-token
dotnet test
```

### Benefits

✅ **Fast Development** - No HTTP overhead
✅ **CI/CD Friendly** - No credentials needed
✅ **Implementation Flexibility** - Swap implementations without changing tests
✅ **Real Integration Tests** - Same tests validate real API when ready
✅ **Clean Architecture** - Enforces interface-based design

See [TESTING.md](TESTING.md) for detailed documentation.

## 📚 Resources

- [IBKR Web API Documentation](https://www.interactivebrokers.com/campus/ibkr-api-page/webapi-doc/)
- [IBKR API Campus](https://ibkrcampus.com/campus/ibkr-api-page/web-api-trading/)
- [Mock Project README](src/IBKR.Api.Client.Mock/README.md)

## 🤝 Contributing

This SDK follows SOLID principles and clean architecture patterns. When contributing:
1. Maintain interface-based design
2. Add XML documentation
3. Include unit tests
4. Follow async/await patterns
5. Use nullable reference types

## 📄 License

[Add your license here]

---

**Status**: 🚧 Foundation Complete - Core features implemented, services and tests pending
