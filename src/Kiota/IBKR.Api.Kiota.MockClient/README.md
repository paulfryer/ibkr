# IBKR.Api.Kiota.MockClient

Mock implementation of IRequestAdapter for testing Kiota-based clients.

## Purpose

This project provides a mock `IRequestAdapter` that returns canned responses for fast,
deterministic testing without network calls.

## Usage

Register the mock adapter via Dependency Injection in tests:

```csharp
var mockAdapter = new MockRequestAdapter();
mockAdapter.SetCannedResponse("/v1/api/fyi/notifications", new List<Notification> { ... });

services.AddSingleton<IRequestAdapter>(mockAdapter);
```

## Implementation Guide

The `MockRequestAdapter` class:

1. Implements `IRequestAdapter` interface
2. Stores canned responses in a dictionary (keyed by request path)
3. Returns canned data when requests are made
4. Throws if no canned response is configured (helps catch test setup issues)

## Example

```csharp
// In test setup
var mockAdapter = new MockRequestAdapter();
mockAdapter.SetCannedResponse("/v1/api/fyi/notifications", new List<NotificationMessage>
{
    new() { Id = "test-1", Message = "Sample notification" }
});

var client = new IBKRClient(mockAdapter);

// In test
var notifications = await client.Fyi.Notifications.GetAsync();
// Returns the canned response
```

## Notes

- This project is **user-editable** and will be preserved during SDK regeneration
- Extend `MockRequestAdapter` as needed for your testing scenarios
- Consider creating helper methods for common test setups
