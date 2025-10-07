using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Fyi service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IFyiService
{
    System.Threading.Tasks.Task DeliveryoptionsDELETEAsync(object deviceId,
        CancellationToken cancellationToken = default);

    Task<DeliveryOptions> DeliveryoptionsGETAsync(CancellationToken cancellationToken = default);

    Task<FyiVT> DeviceAsync(FyiEnableDeviceOption body, CancellationToken cancellationToken = default);

    Task<DisclaimerInfo> DisclaimerGETAsync(Typecodes typecode, CancellationToken cancellationToken = default);

    Task<FyiVT> DisclaimerPUTAsync(Typecodes typecode, CancellationToken cancellationToken = default);

    Task<FyiVT> EmailAsync(object enabled, CancellationToken cancellationToken = default);

    Task<ICollection<Anonymous>> NotificationsAllAsync(string max, object? include = null, object? exclude = null,
        object? id = null, CancellationToken cancellationToken = default);

    Task<NotificationReadAcknowledge> NotificationsAsync(object notificationId,
        CancellationToken cancellationToken = default);

    Task<ICollection<Anonymous2>> SettingsAllAsync(CancellationToken cancellationToken = default);

    Task<FyiVT> SettingsAsync(Typecodes typecode, Body body, CancellationToken cancellationToken = default);

    Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default);
}