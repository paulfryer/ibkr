# IBKR.Api.NSwag.MockClient

Mock implementations of service interfaces for testing.

## Purpose

This project provides mock implementations of the service interfaces defined in `IBKR.Api.NSwag.Contract`.
These mocks return canned responses for fast, deterministic testing without network calls.

## Usage

Mocks are registered via Dependency Injection in tests:

```csharp
services.AddTransient<IFyiService, MockFyiService>();
services.AddTransient<IGwService, MockGwService>();
// ... etc
```

## Implementation Guide

For each service interface in `IBKR.Api.NSwag.Contract.Interfaces`:

1. Create a mock class: `Mock{ServiceName}.cs`
2. Implement the interface
3. Return canned data (hardcoded responses)
4. Consider using helper methods for common test scenarios

## Example

```csharp
public class MockFyiService : IFyiService
{
    public async Task<ICollection<NotificationMessage>> GetNotificationsAsync(CancellationToken cancellationToken = default)
    {
        // Return canned test data
        return await Task.FromResult(new List<NotificationMessage>
        {
            new NotificationMessage { Id = "test-1", Message = "Sample notification" }
        });
    }
}
```

## Notes

- This project is **user-editable** and will be preserved during SDK regeneration
- Implement only the methods you need for your tests
- Use async/await for consistency with real services
