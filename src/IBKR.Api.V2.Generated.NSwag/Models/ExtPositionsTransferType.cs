using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ExtPositionsTransferType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("partialStockPositions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PartialStockPosition> PartialStockPositions { get; set; } = null;


	[JsonProperty("partialBondPositions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PartialBondPosition> PartialBondPositions { get; set; } = null;


	[JsonProperty("partialOptionPositions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PartialOptionPosition> PartialOptionPositions { get; set; } = null;


	[JsonProperty("partialWarrantPositions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PartialWarrantPosition> PartialWarrantPositions { get; set; } = null;


	[JsonProperty("partialFundPositions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PartialFundPosition> PartialFundPositions { get; set; } = null;


	[JsonProperty("partialCashPositions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<PartialCashPosition> PartialCashPositions { get; set; } = null;


	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ExtPositionsTransferTypeType Type { get; set; } = ExtPositionsTransferTypeType.FULL;


	[JsonProperty("subType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ExtPositionsTransferTypeSubType SubType { get; set; } = ExtPositionsTransferTypeSubType.ACATS;


	[JsonProperty("brokerId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BrokerId { get; set; } = null;


	[JsonProperty("brokerName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BrokerName { get; set; } = null;


	[JsonProperty("accountAtBroker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountAtBroker { get; set; } = null;


	[JsonProperty("srcIRAType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public ExtPositionsTransferTypeSrcIRAType SrcIRAType { get; set; } = ExtPositionsTransferTypeSrcIRAType.RI;


	[JsonProperty("marginLoan", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool MarginLoan { get; set; } = false;


	[JsonProperty("shortPos", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ShortPos { get; set; } = false;


	[JsonProperty("optionPos", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OptionPos { get; set; } = false;


	[JsonProperty("ibAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string IbAccount { get; set; } = null;


	[JsonProperty("thirdPartyType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ThirdPartyType { get; set; } = null;


	[JsonProperty("approximateAccountValue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ApproximateAccountValue { get; set; } = 0;


	[JsonProperty("ssn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ssn { get; set; } = null;


	[JsonProperty("ein", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ein { get; set; } = null;


	[JsonProperty("signature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Signature { get; set; } = null;


	[JsonProperty("authorizeToRemoveFund", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool AuthorizeToRemoveFund { get; set; } = false;


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
