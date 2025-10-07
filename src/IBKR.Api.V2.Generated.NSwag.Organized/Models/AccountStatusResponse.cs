using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccountStatusResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("dateOpened", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset DateOpened { get; set; } = default(DateTimeOffset);

	[JsonProperty("dateStarted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset DateStarted { get; set; } = default(DateTimeOffset);

	[JsonProperty("dateClosed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset DateClosed { get; set; } = default(DateTimeOffset);

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Status { get; set; } = null;

	[JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description { get; set; } = null;

	[JsonProperty("masterAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MasterAccountId { get; set; } = null;

	[JsonProperty("adminAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AdminAccountId { get; set; } = null;

	[JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string State { get; set; } = null;

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
