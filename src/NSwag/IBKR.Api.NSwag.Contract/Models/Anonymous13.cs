using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous13
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("kty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public Kty Kty { get; set; } = Kty.RSA;


	[JsonProperty("use", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public Use Use { get; set; } = Use.Sig;


	[JsonProperty("kid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Kid { get; set; } = null;


	[JsonProperty("alg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Alg { get; set; } = null;


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
