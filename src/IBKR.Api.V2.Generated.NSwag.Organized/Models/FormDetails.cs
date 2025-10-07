using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormDetails
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int FormNumber { get; set; } = 0;

	[JsonProperty("sha1Checksum", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Sha1Checksum { get; set; } = null;

	[JsonProperty("dateModified", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset DateModified { get; set; } = default(DateTimeOffset);

	[JsonProperty("fileName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FileName { get; set; } = null;

	[JsonProperty("language", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Language { get; set; } = null;

	[JsonProperty("formName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormName { get; set; } = null;

	[JsonProperty("payload", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FormPayload Payload { get; set; } = null;

	[JsonProperty("apiSupportedTask", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ApiSupportedTask { get; set; } = false;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Type { get; set; } = null;

	[JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Action { get; set; } = null;

	[JsonProperty("acceptableDocs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> AcceptableDocs { get; set; } = null;

	[JsonProperty("questionnaire", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<QuestionnaireResponse> Questionnaire { get; set; } = null;

	[JsonProperty("error", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ErrorResponse Error { get; set; } = null;

	[JsonProperty("hasError", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool HasError { get; set; } = false;

	[JsonProperty("errorDescription", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ErrorDescription { get; set; } = null;

	[JsonProperty("fileLength", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public long FileLength { get; set; } = 0L;

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
