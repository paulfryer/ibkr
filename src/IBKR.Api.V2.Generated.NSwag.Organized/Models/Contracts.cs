using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Contracts
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("server_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Server_id { get; set; } = null;

	[JsonProperty("column_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Column_name { get; set; } = null;

	[JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } = null;

	[JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Conidex { get; set; } = null;

	[JsonProperty("con_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Con_id { get; set; } = 0;

	[JsonProperty("available_chart_periods", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Available_chart_periods { get; set; } = null;

	[JsonProperty("company_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Company_name { get; set; } = null;

	[JsonProperty("contract_description_1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Contract_description_1 { get; set; } = null;

	[JsonProperty("listing_exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Listing_exchange { get; set; } = null;

	[JsonProperty("sec_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Sec_type { get; set; } = null;

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
