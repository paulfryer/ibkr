using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ProhibitedQuestionnaireDetail
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ProhibitedQuestionnaireDetailCode Code { get; set; } = ProhibitedQuestionnaireDetailCode.PASSPORT;

	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Status { get; set; } = false;

	[JsonProperty("details", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Details { get; set; } = null;

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
