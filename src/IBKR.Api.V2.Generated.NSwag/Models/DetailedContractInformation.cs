using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DetailedContractInformation
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("currencyType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CurrencyType { get; set; } = null;


	[JsonProperty("rc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Rc { get; set; } = 0;


	[JsonProperty("view", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> View { get; set; } = null;


	[JsonProperty("nd", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Nd { get; set; } = 0;


	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;


	[JsonProperty("included", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Included { get; set; } = null;


	[JsonProperty("pm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Pm { get; set; } = null;


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
