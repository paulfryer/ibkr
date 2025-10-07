using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Interfaces;

/// <summary>
/// Fyi service operations
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IFyiService
{
	System.Threading.Tasks.Task DeliveryoptionsDELETEAsync(object deviceId, CancellationToken cancellationToken = default(CancellationToken));

	Task<DeliveryOptions> DeliveryoptionsGETAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> DeviceAsync(FyiEnableDeviceOption body, CancellationToken cancellationToken = default(CancellationToken));

	Task<DisclaimerInfo> DisclaimerGETAsync(Typecodes typecode, CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> DisclaimerPUTAsync(Typecodes typecode, CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> EmailAsync(object enabled, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous>> NotificationsAllAsync(string max, object? include = null, object? exclude = null, object? id = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<NotificationReadAcknowledge> NotificationsAsync(object notificationId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ICollection<Anonymous2>> SettingsAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<FyiVT> SettingsAsync(Typecodes typecode, Body body, CancellationToken cancellationToken = default(CancellationToken));

	Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default(CancellationToken));

}
