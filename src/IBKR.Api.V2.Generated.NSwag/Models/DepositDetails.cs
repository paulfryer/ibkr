using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DepositDetails
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("amount", Required = Required.Always)]
	public double Amount { get; set; } = 0.0;


	[JsonProperty("currency", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Currency { get; set; } = null;


	[JsonProperty("whenAvailable", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string WhenAvailable { get; set; } = null;


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
