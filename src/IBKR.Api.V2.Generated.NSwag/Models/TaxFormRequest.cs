using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class TaxFormRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;


	[JsonProperty("year", Required = Required.Always)]
	public int Year { get; set; } = 0;


	[JsonProperty("type", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Type { get; set; } = null;


	[JsonProperty("format", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Format { get; set; } = null;


	[JsonProperty("gzip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Gzip { get; set; } = false;


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
