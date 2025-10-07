using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Body13
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("name", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Name { get; set; } = null;

	[JsonProperty("accounts", Required = Required.Always)]
	[Required]
	public ICollection<object> Accounts { get; set; } = new Collection<object>();

	[JsonProperty("default_method", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public AllocationMethod Default_method { get; set; } = AllocationMethod.A;

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
