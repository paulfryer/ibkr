using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class LoginMessage
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("recordDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset RecordDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Id { get; set; } = 0;

	[JsonProperty("username", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Username { get; set; } = null;

	[JsonProperty("messageType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MessageType { get; set; } = null;

	[JsonProperty("contentId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ContentId { get; set; } = 0;

	[JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string State { get; set; } = null;

	[JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description { get; set; } = null;

	[JsonProperty("tasks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<int> Tasks { get; set; } = null;

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
