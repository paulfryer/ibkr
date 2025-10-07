using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ACHInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("custInitAch", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool CustInitAch { get; set; } = false;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ACHInstructionType Type { get; set; } = ACHInstructionType.CREDIT;


	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;


	[JsonProperty("bankName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankName { get; set; } = null;


	[JsonProperty("ibAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IbAccount { get; set; } = null;


	[JsonProperty("bankCountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BankCountry { get; set; } = null;


	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ACHInstructionCurrency Currency { get; set; } = ACHInstructionCurrency.USD;


	[JsonProperty("routingNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RoutingNumber { get; set; } = null;


	[JsonProperty("accountNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountNumber { get; set; } = null;


	[JsonProperty("accountType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ACHInstructionAccountType AccountType { get; set; } = ACHInstructionAccountType.Savings;


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
