using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IraDepositDetail
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("iraContributionType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IraDepositDetailIraContributionType IraContributionType { get; set; } = IraDepositDetailIraContributionType.ROLLOVER;

	[JsonProperty("iraTaxYearType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IraDepositDetailIraTaxYearType IraTaxYearType { get; set; } = IraDepositDetailIraTaxYearType.CURRENT;

	[JsonProperty("fromIraType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IraDepositDetailFromIraType FromIraType { get; set; } = IraDepositDetailFromIraType.NONE;

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
