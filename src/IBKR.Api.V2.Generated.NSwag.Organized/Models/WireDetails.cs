using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class WireDetails
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("bankName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankName { get; set; } = null;

	[JsonProperty("bankAccountNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankAccountNumber { get; set; } = null;

	[JsonProperty("bankCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankCode { get; set; } = null;

	[JsonProperty("routingNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RoutingNumber { get; set; } = null;

	[JsonProperty("instruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Instruction { get; set; } = null;

	[JsonProperty("countryCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryCode { get; set; } = null;

	[JsonProperty("referenceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ReferenceNumber { get; set; } = null;

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
