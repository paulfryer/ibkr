using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Orders
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("acct", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Acct { get; set; } = null;


	[JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Exchange { get; set; } = null;


	[JsonProperty("conidex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Conidex { get; set; } = null;


	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Conid { get; set; } = null;


	[JsonProperty("account", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Account { get; set; } = null;


	[JsonProperty("orderId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int OrderId { get; set; } = 0;


	[JsonProperty("cashCcy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CashCcy { get; set; } = null;


	[JsonProperty("sizeAndFills", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SizeAndFills { get; set; } = null;


	[JsonProperty("orderDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OrderDesc { get; set; } = null;


	[JsonProperty("description1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description1 { get; set; } = null;


	[JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ticker { get; set; } = null;


	[JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SecType { get; set; } = null;


	[JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ListingExchange { get; set; } = null;


	[JsonProperty("remainingQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string RemainingQuantity { get; set; } = null;


	[JsonProperty("filledQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FilledQuantity { get; set; } = null;


	[JsonProperty("totalSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TotalSize { get; set; } = null;


	[JsonProperty("totalCashSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TotalCashSize { get; set; } = null;


	[JsonProperty("companyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CompanyName { get; set; } = null;


	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public OrdersStatus Status { get; set; } = OrdersStatus.Inactive;


	[JsonProperty("order_ccp_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Order_ccp_status { get; set; } = null;


	[JsonProperty("origOrderType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OrigOrderType { get; set; } = null;


	[JsonProperty("supportsTaxOpt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public OrdersSupportsTaxOpt SupportsTaxOpt { get; set; } = OrdersSupportsTaxOpt._0;


	[JsonProperty("lastExecutionTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastExecutionTime { get; set; } = null;


	[JsonProperty("orderType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string OrderType { get; set; } = null;


	[JsonProperty("bgColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string BgColor { get; set; } = null;


	[JsonProperty("fgColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string FgColor { get; set; } = null;


	[JsonProperty("isEventTrading", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public OrdersIsEventTrading IsEventTrading { get; set; } = OrdersIsEventTrading._0;


	[JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Price { get; set; } = null;


	[JsonProperty("timeInForce", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TimeInForce { get; set; } = null;


	[JsonProperty("lastExecutionTime_r", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string LastExecutionTime_r { get; set; } = null;


	[JsonProperty("side", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Side { get; set; } = null;


	[JsonProperty("avgPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AvgPrice { get; set; } = null;


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
