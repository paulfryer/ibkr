using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RegistrationTask
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int FormNumber { get; set; } = 0;

	[JsonProperty("formName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormName { get; set; } = null;

	[JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Action { get; set; } = null;

	[JsonProperty("dateCompleted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset DateCompleted { get; set; } = default(DateTimeOffset);

	[JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string State { get; set; } = null;

	[JsonProperty("questionIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<int> QuestionIds { get; set; } = null;

	[JsonProperty("warning", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Warning { get; set; } = null;

	[JsonProperty("isRequiredForApproval", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsRequiredForApproval { get; set; } = false;

	[JsonProperty("isCompleted", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsCompleted { get; set; } = false;

	[JsonProperty("isDeclined", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsDeclined { get; set; } = false;

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
