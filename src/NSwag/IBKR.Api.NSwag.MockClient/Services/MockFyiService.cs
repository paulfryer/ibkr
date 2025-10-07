using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.MockClient.Services;

/// <summary>
/// Mock implementation of IFyiService for testing.
/// Returns canned responses to simulate API behavior without network calls.
/// </summary>
public class MockFyiService : IFyiService
{
    // TODO: Replace NotImplementedException with canned responses for the methods you need to test

    public System.Threading.Tasks.Task DeliveryoptionsDELETEAsync(object deviceId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.DeliveryoptionsDELETEAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<DeliveryOptions> DeliveryoptionsGETAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.DeliveryoptionsGETAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<FyiVT> DeviceAsync(FyiEnableDeviceOption body, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.DeviceAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<DisclaimerInfo> DisclaimerGETAsync(Typecodes typecode, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.DisclaimerGETAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<FyiVT> DisclaimerPUTAsync(Typecodes typecode, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.DisclaimerPUTAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<FyiVT> EmailAsync(object enabled, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.EmailAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<ICollection<Anonymous>> NotificationsAllAsync(string max, object? include = null, object? exclude = null, object? id = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.NotificationsAllAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<NotificationReadAcknowledge> NotificationsAsync(object notificationId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.NotificationsAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<ICollection<Anonymous2>> SettingsAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.SettingsAllAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<FyiVT> SettingsAsync(Typecodes typecode, Body body, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.SettingsAsync not implemented. Add a canned response.");
    }

    public System.Threading.Tasks.Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("MockFyiService.UnreadnumberAsync not implemented. Add a canned response.");
    }
}
