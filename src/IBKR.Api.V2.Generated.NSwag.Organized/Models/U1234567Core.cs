using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class U1234567Core
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("rowType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int RowType { get; set; } = 0;

	[JsonProperty("dpl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Dpl { get; set; } = 0;

	[JsonProperty("nl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Nl { get; set; } = 0;

	[JsonProperty("upl", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Upl { get; set; } = 0;

	[JsonProperty("el", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int El { get; set; } = 0;

	[JsonProperty("mv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Mv { get; set; } = 0;

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
