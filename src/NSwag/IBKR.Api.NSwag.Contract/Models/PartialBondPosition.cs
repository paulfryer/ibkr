using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PartialBondPosition
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("cusipNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CusipNumber { get; set; } = null;


	[JsonProperty("numberOfBonds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long NumberOfBonds { get; set; } = 0L;


	[JsonProperty("all", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool All { get; set; } = false;


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
