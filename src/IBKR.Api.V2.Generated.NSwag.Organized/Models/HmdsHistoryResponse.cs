using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class HmdsHistoryResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("startTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string StartTime { get; set; } = null;

	[JsonProperty("startTimeVal", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int StartTimeVal { get; set; } = 0;

	[JsonProperty("endTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string EndTime { get; set; } = null;

	[JsonProperty("endTimeVal", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int EndTimeVal { get; set; } = 0;

	[JsonProperty("Data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<SingleHistoricalBar> Data { get; set; } = null;

	[JsonProperty("points", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Points { get; set; } = 0;

	[JsonProperty("mktDataDelay", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int MktDataDelay { get; set; } = 0;

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
