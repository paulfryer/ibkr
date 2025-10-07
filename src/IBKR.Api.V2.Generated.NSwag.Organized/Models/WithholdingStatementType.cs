using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.V2.Generated.NSwag.Helpers;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class WithholdingStatementType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("fatcaCompliantType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public WithholdingStatementTypeFatcaCompliantType FatcaCompliantType { get; set; } = WithholdingStatementTypeFatcaCompliantType.FATCA_COMPLIANT;

	[JsonProperty("usBackupWithholding", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool UsBackupWithholding { get; set; } = false;

	[JsonProperty("treatyCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TreatyCountry { get; set; } = null;

	[JsonProperty("corporation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Corporation { get; set; } = false;

	[JsonProperty("flowThrough", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool FlowThrough { get; set; } = false;

	[JsonProperty("effectiveDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset EffectiveDate { get; set; } = default(DateTimeOffset);

	[JsonProperty("dividendRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public float DividendRate { get; set; } = 0f;

	[JsonProperty("interestRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public float InterestRate { get; set; } = 0f;

	[JsonProperty("usOtherRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public float UsOtherRate { get; set; } = 0f;

	[JsonProperty("eciRate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public float EciRate { get; set; } = 0f;

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
