using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SingleOrderSubmissionRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("acctId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AcctId { get; set; } = null;


	[JsonProperty("conid", Required = Required.Always)]
	public int Conid { get; set; } = 0;


	[JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Conidex { get; set; } = null;


	[JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SecType { get; set; } = null;


	[JsonProperty("cOID", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string COID { get; set; } = null;


	[JsonProperty("parentId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ParentId { get; set; } = null;


	[JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ListingExchange { get; set; } = null;


	[JsonProperty("isSingleGroup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsSingleGroup { get; set; } = false;


	[JsonProperty("outsideRTH", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool OutsideRTH { get; set; } = false;


	[JsonProperty("auxPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double AuxPrice { get; set; } = 0.0;


	[JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ticker { get; set; } = null;


	[JsonProperty("trailingAmt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double TrailingAmt { get; set; } = 0.0;


	[JsonProperty("trailingType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public SingleOrderSubmissionRequestTrailingType TrailingType { get; set; } = SingleOrderSubmissionRequestTrailingType.Amt;


	[JsonProperty("referrer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Referrer { get; set; } = null;


	[JsonProperty("cashQty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double CashQty { get; set; } = 0.0;


	[JsonProperty("useAdaptive", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool UseAdaptive { get; set; } = false;


	[JsonProperty("isCcyConv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsCcyConv { get; set; } = false;


	[JsonProperty("orderType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string OrderType { get; set; } = null;


	[JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Price { get; set; } = 0.0;


	[JsonProperty("side", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public SingleOrderSubmissionRequestSide Side { get; set; } = SingleOrderSubmissionRequestSide.BUY;


	[JsonProperty("tif", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public SingleOrderSubmissionRequestTif Tif { get; set; } = SingleOrderSubmissionRequestTif.DAY;


	[JsonProperty("quantity", Required = Required.Always)]
	public double Quantity { get; set; } = 0.0;


	[JsonProperty("strategy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Strategy { get; set; } = null;


	[JsonProperty("strategyParameters", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public StrategyParameters StrategyParameters { get; set; } = null;


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
