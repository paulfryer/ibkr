using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InternalServerErrorResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("type", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Type { get; set; } = null;


	[JsonProperty("title", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Title { get; set; } = null;


	[JsonProperty("status", Required = Required.Always)]
	public int Status { get; set; } = 0;


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
