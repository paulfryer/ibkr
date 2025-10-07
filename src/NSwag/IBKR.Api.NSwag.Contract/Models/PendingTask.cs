using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PendingTask
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("taskNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int TaskNumber { get; set; } = 0;


	[JsonProperty("formNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int FormNumber { get; set; } = 0;


	[JsonProperty("formName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FormName { get; set; } = null;


	[JsonProperty("action", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Action { get; set; } = null;


	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;


	[JsonProperty("state", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string State { get; set; } = null;


	[JsonProperty("documentRejectReason", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> DocumentRejectReason { get; set; } = null;


	[JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Url { get; set; } = null;


	[JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset StartDate { get; set; } = default(DateTimeOffset);


	[JsonProperty("au10tixCreatedDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset Au10tixCreatedDate { get; set; } = default(DateTimeOffset);


	[JsonProperty("au10tixExpiryDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DateTimeOffset Au10tixExpiryDate { get; set; } = default(DateTimeOffset);


	[JsonProperty("entityId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int EntityId { get; set; } = 0;


	[JsonProperty("onlineTask", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OnlineTask { get; set; } = false;


	[JsonProperty("requiredForApproval", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool RequiredForApproval { get; set; } = false;


	[JsonProperty("requiredForTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool RequiredForTrading { get; set; } = false;


	[JsonProperty("questionIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<int> QuestionIds { get; set; } = null;


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
