using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Answer
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("answerDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AnswerDetail> AnswerDetail { get; set; } = null;


	[JsonProperty("detail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Detail { get; set; } = null;


	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Id { get; set; } = 0;


	[JsonProperty("questionId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int QuestionId { get; set; } = 0;


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
