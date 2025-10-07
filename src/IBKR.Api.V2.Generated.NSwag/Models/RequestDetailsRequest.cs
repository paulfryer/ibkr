using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.V2.Generated.NSwag.Helpers;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class RequestDetailsRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("startDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset StartDate { get; set; } = default(DateTimeOffset);


	[JsonProperty("endDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset EndDate { get; set; } = default(DateTimeOffset);


	[JsonProperty("offset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[Range(0, int.MaxValue)]
	public int Offset { get; set; } = 0;


	[JsonProperty("limit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[Range(1, 1000)]
	public int Limit { get; set; } = 0;


	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public RequestDetailsRequestStatus Status { get; set; } = RequestDetailsRequestStatus.N;


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
