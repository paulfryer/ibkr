using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.V2.Generated.NSwag.Helpers;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class DVPInstruction
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Id { get; set; } = null;

	[JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalId { get; set; } = null;

	[JsonProperty("externalAccountID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalAccountID { get; set; } = null;

	[JsonProperty("accountID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountID { get; set; } = null;

	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;

	[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DVPInstructionType Type { get; set; } = DVPInstructionType.DTCID;

	[JsonProperty("role", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DVPInstructionRole Role { get; set; } = DVPInstructionRole.E;

	[JsonProperty("agentID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AgentID { get; set; } = null;

	[JsonProperty("firmID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FirmID { get; set; } = null;

	[JsonProperty("agentName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AgentName { get; set; } = null;

	[JsonProperty("accountName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountName { get; set; } = null;

	[JsonProperty("dayDoID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DayDoID { get; set; } = null;

	[JsonProperty("txGroupCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DVPInstructionTxGroupCode TxGroupCode { get; set; } = DVPInstructionTxGroupCode.G;

	[JsonProperty("brokerCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BrokerCode { get; set; } = null;

	[JsonProperty("assetClass", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DVPInstructionAssetClass AssetClass { get; set; } = DVPInstructionAssetClass.BILL;

	[JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DVPInstructionExchange Exchange { get; set; } = DVPInstructionExchange.NYSE;

	[JsonProperty("prepayTax", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PrepayTax { get; set; } = false;

	[JsonProperty("prepayCommission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool PrepayCommission { get; set; } = false;

	[JsonProperty("expiry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset Expiry { get; set; } = default(DateTimeOffset);

	[JsonProperty("default", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Default { get; set; } = false;

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
