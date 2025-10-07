using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class QuestionnaireResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("questionId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long QuestionId { get; set; } = 0L;


	[JsonProperty("question", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Question { get; set; } = null;


	[JsonProperty("isMandatoryToAnswer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsMandatoryToAnswer { get; set; } = false;


	[JsonProperty("questionType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string QuestionType { get; set; } = null;


	[JsonProperty("answers", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<AnswerResponse> Answers { get; set; } = null;


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
