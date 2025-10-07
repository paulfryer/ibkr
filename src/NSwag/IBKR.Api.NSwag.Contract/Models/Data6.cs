using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Data6
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("scanners_only", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Scanners_only { get; set; } = false;


	[JsonProperty("show_scanners", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Show_scanners { get; set; } = false;


	[JsonProperty("bulk_delete", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Bulk_delete { get; set; } = false;


	[JsonProperty("user_lists", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<User_lists> User_lists { get; set; } = null;


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
