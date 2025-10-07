using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IraWithdrawalDetail
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("fedIncomeTaxPercentage", Required = Required.Always)]
	public double FedIncomeTaxPercentage { get; set; } = 0.0;


	[JsonProperty("stateIncomeTaxPercentage", Required = Required.Always)]
	public double StateIncomeTaxPercentage { get; set; } = 0.0;


	[JsonProperty("stateCd", Required = Required.Always)]
	[Required]
	[StringLength(2, MinimumLength = 1)]
	public string StateCd { get; set; } = null;


	[JsonProperty("iraWithholdType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public IraWithdrawalDetailIraWithholdType IraWithholdType { get; set; } = IraWithdrawalDetailIraWithholdType.DIRECT_ROLLOVER;


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
