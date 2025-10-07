# IBKR.Api.Kiota.Tests

xUnit tests with Dependency Injection support for Kiota (Fluent API) SDK.

## Architecture

**Tests depend on INTERFACES, not implementations.**

This allows the same tests to run against:
- **Mock implementations** (CI/CD build server - fast, deterministic)
- **Real implementations** (Local development - integration testing)

Simply change the `appsettings.json` configuration to switch between mock and real clients.

## Configuration

### appsettings.test.json (CI/CD)
```json
{
  "Testing": {
    "UseMockClient": true
  }
}
```

### appsettings.development.json (Local)
```json
{
  "Testing": {
    "UseMockClient": false
  },
  "IBKR": {
    "BaseUrl": "https://api.ibkr.com",
    "ApiKey": "your-api-key-here"
  }
}
```

## Dependency Injection

Tests use `TestFixture` to configure DI based on configuration:

```csharp
services.AddSingleton<IRequestAdapter>(new MockRequestAdapter());  // Mock for CI/CD
// OR
services.AddSingleton<IRequestAdapter>(new HttpClientRequestAdapter(...)); // Real for local testing
```

## Running Tests

```bash
# Run all tests (uses appsettings.json configuration)
dotnet test

# Run with specific configuration
ASPNETCORE_ENVIRONMENT=test dotnet test          # Use mock client
ASPNETCORE_ENVIRONMENT=development dotnet test   # Use real client
```

## Writing Tests

```csharp
public class MyServiceTests : IClassFixture<TestFixture>
{
    private readonly IMyService _service;

    public MyServiceTests(TestFixture fixture)
    {
        _service = fixture.GetService<IMyService>();
        // Test doesn't know if this is mock or real!
    }

    [Fact]
    public async Task MyTest()
    {
        var result = await _service.DoSomethingAsync();
        Assert.NotNull(result);
    }
}
```

## Notes

- This project is **user-editable** and will be preserved during SDK regeneration
- Tests verify interface contracts, not implementation details
- Same test code works for both mock and real clients
- Build server uses mocks (fast, no credentials needed)
- Local developers can test against real API (integration testing)
