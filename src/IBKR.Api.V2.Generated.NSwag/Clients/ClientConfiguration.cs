using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.V2.Generated.NSwag.Models;

namespace IBKR.Api.V2.Generated.NSwag.Clients;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ClientConfiguration
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("account_selection_mode", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ClientConfigurationAccount_selection_mode Account_selection_mode { get; set; } = ClientConfigurationAccount_selection_mode.SINGLE;


	[JsonProperty("filter", Required = Required.Always)]
	[Required]
	public IDictionary<string, object> Filter { get; set; } = new Dictionary<string, object>();


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
