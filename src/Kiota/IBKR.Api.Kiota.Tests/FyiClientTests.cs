using IBKR.Api.Kiota.Client;
using Microsoft.Kiota.Abstractions;
using Xunit;

namespace IBKR.Api.Kiota.Tests;

/// <summary>
/// Example tests for Kiota-based client.
/// IRequestAdapter implementation (Mock or Real) is injected via DI based on appsettings.json configuration.
/// </summary>
public class FyiClientTests : IClassFixture<TestFixture>
{
    private readonly IBKRClient _client;

    public FyiClientTests(TestFixture fixture)
    {
        var requestAdapter = fixture.GetService<IRequestAdapter>();
        _client = new IBKRClient(requestAdapter);
    }

    [Fact(Skip = "TODO: Implement MockRequestAdapter with canned responses for /fyi/notifications")]
    public async Task GetNotifications_ShouldReturnData()
    {
        // Act
        var result = await _client.Fyi.Notifications.GetAsync();

        // Assert
        Assert.NotNull(result);
        // TODO: Add more assertions based on API response
    }

    [Fact(Skip = "Example test - implement when client is complete")]
#pragma warning disable CS1998 // Async method lacks 'await' operators
    public async Task ExampleTest_VerifyBehavior()
#pragma warning restore CS1998
    {
        // Arrange
        // Act
        // Assert
        Assert.True(true);
    }
}
