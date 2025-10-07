using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class U1234567
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("hasChildAccounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasChildAccounts { get; set; } = false;


	[JsonProperty("supportsCashQty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool SupportsCashQty { get; set; } = false;


	[JsonProperty("noFXConv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool NoFXConv { get; set; } = false;


	[JsonProperty("isProp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsProp { get; set; } = false;


	[JsonProperty("supportsFractions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool SupportsFractions { get; set; } = false;


	[JsonProperty("allowCustomerTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AllowCustomerTime { get; set; } = false;


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
