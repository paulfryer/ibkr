using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Securities2
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("net_liquidation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Net_liquidation { get; set; } = null;

	[JsonProperty("equity_with_loan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Equity_with_loan { get; set; } = null;

	[JsonProperty("Prvs Dy Eqty Wth Ln Vl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Prvs_Dy_Eqty_Wth_Ln_Vl { get; set; } = null;

	[JsonProperty("sec_gross_pos_val", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Sec_gross_pos_val { get; set; } = null;

	[JsonProperty("cash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Cash { get; set; } = null;

	[JsonProperty("MTD Interest", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MTD_Interest { get; set; } = null;

	[JsonProperty("Pndng Dbt Crd Chrgs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Pndng_Dbt_Crd_Chrgs { get; set; } = null;

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
