using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Total3
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("current_initial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Current_initial { get; set; } = null;

	[JsonProperty("Prdctd Pst-xpry Mrgn @ Opn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Prdctd_PstXpry_Mrgn__Opn { get; set; } = null;

	[JsonProperty("current_maint", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Current_maint { get; set; } = null;

	[JsonProperty("projected_liquidity_inital_margin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Projected_liquidity_inital_margin { get; set; } = null;

	[JsonProperty("Prjctd Lk Ahd Mntnnc Mrgn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Prjctd_Lk_Ahd_Mntnnc_Mrgn { get; set; } = null;

	[JsonProperty("projected_overnight_initial_margin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Projected_overnight_initial_margin { get; set; } = null;

	[JsonProperty("Prjctd Ovrnght Mntnnc Mrgn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Prjctd_Ovrnght_Mntnnc_Mrgn { get; set; } = null;

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
