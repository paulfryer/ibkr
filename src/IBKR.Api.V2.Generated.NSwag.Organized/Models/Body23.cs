using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body23
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("id", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Id { get; set; } = null;

	[JsonProperty("name", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Name { get; set; } = null;

	[JsonProperty("rows", Required = Required.Always)]
	[Required]
	public ICollection<object> Rows { get; set; } = new Collection<object>();

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
