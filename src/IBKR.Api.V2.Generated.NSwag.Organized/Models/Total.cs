using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Total
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("current_available", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Current_available { get; set; } = null;

	[JsonProperty("current_excess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Current_excess { get; set; } = null;

	[JsonProperty("Prdctd Pst-xpry Excss", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Prdctd_PstXpry_Excss { get; set; } = null;

	[JsonProperty("Lk Ahd Avlbl Fnds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Lk_Ahd_Avlbl_Fnds { get; set; } = null;

	[JsonProperty("Lk Ahd Excss Lqdty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Lk_Ahd_Excss_Lqdty { get; set; } = null;

	[JsonProperty("overnight_available", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Overnight_available { get; set; } = null;

	[JsonProperty("overnight_excess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Overnight_excess { get; set; } = null;

	[JsonProperty("buying_power", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Buying_power { get; set; } = null;

	[JsonProperty("leverage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Leverage { get; set; } = null;

	[JsonProperty("Lk Ahd Nxt Chng", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Lk_Ahd_Nxt_Chng { get; set; } = null;

	[JsonProperty("day_trades_left", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Day_trades_left { get; set; } = null;

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
