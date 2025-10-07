using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body22
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("symbol", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Symbol { get; set; } = null;


	[JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public Body22SecType SecType { get; set; } = Body22SecType.STK;


	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Name { get; set; } = false;


	[JsonProperty("more", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool More { get; set; } = false;


	[JsonProperty("fund", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Fund { get; set; } = false;


	[JsonProperty("fundFamilyConidEx", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FundFamilyConidEx { get; set; } = null;


	[JsonProperty("pattern", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Pattern { get; set; } = false;


	[JsonProperty("referrer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Referrer { get; set; } = null;


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
