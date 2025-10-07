using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.V2.Generated.NSwag.Helpers;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UpdateWithholdingStatement
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("fatcaCompliantType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public UpdateWithholdingStatementFatcaCompliantType FatcaCompliantType { get; set; } = UpdateWithholdingStatementFatcaCompliantType.FATCA_COMPLIANT;

	[JsonProperty("usIncomeTax", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool UsIncomeTax { get; set; } = false;

	[JsonProperty("treatyCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TreatyCountry { get; set; } = null;

	[JsonProperty("certW8Imy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool CertW8Imy { get; set; } = false;

	[JsonProperty("effectiveDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset EffectiveDate { get; set; } = default(DateTimeOffset);

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
