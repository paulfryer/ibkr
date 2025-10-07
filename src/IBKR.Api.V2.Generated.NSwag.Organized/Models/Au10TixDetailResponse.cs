using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Au10TixDetailResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset StartDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("expiryDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset ExpiryDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ErrorResponse Error { get; set; } = null;

	[JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasError { get; set; } = false;

	[JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ErrorDescription { get; set; } = null;

	[JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Url { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int EntityId { get; set; } = 0;

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
