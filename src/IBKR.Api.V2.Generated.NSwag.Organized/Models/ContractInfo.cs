using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ContractInfo
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("cfi_code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Cfi_code { get; set; }

    [JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("cusip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Cusip { get; set; }

    [JsonProperty("expiry_full", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Expiry_full { get; set; }

    [JsonProperty("con_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Con_id { get; set; }

    [JsonProperty("maturity_date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Maturity_date { get; set; }

    [JsonProperty("industry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Industry { get; set; }

    [JsonProperty("instrument_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Instrument_type { get; set; }

    [JsonProperty("trading_class", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Trading_class { get; set; }

    [JsonProperty("valid_exchanges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Valid_exchanges { get; set; }

    [JsonProperty("allow_sell_long", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Allow_sell_long { get; set; }

    [JsonProperty("is_zero_commission_security", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public bool Is_zero_commission_security { get; set; }

    [JsonProperty("local_symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Local_symbol { get; set; }

    [JsonProperty("contract_clarification_type", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string Contract_clarification_type { get; set; }

    [JsonProperty("classifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Classifier { get; set; }

    [JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Currency { get; set; }

    [JsonProperty("text", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Text { get; set; }

    [JsonProperty("underlying_con_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int Underlying_con_id { get; set; }

    [JsonProperty("r_t_h", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool R_t_h { get; set; }

    [JsonProperty("multiplier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Multiplier { get; set; }

    [JsonProperty("underlying_issuer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Underlying_issuer { get; set; }

    [JsonProperty("contract_month", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Contract_month { get; set; }

    [JsonProperty("company_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Company_name { get; set; }

    [JsonProperty("smart_available", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Smart_available { get; set; }

    [JsonProperty("exchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Exchange { get; set; }

    [JsonProperty("category", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Category { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}