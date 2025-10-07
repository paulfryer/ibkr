using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class SecDefInfoResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Conid { get; set; } = 0;

	[JsonProperty("ticker", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Ticker { get; set; } = null;

	[JsonProperty("secType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SecType { get; set; } = null;

	[JsonProperty("listingExchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ListingExchange { get; set; } = null;

	[JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Exchange { get; set; } = null;

	[JsonProperty("companyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CompanyName { get; set; } = null;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Currency { get; set; } = null;

	[JsonProperty("validExchanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ValidExchanges { get; set; } = null;

	[JsonProperty("priceRendering", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public object? PriceRendering { get; set; } = null;

	[JsonProperty("maturityDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? MaturityDate { get; set; } = null;

	[JsonProperty("right", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public SecDefInfoResponseRight Right { get; set; } = SecDefInfoResponseRight.P;

	[JsonProperty("strike", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double Strike { get; set; } = 0.0;

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
