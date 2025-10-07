using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class NonDisclosedDetail
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("tradeDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string TradeDate { get; set; }

    [JsonProperty("settleDate", Required = Required.Always)]
    [Required(AllowEmptyStrings = true)]
    public string SettleDate { get; set; }

    [JsonProperty("psetBic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64)]
    public string PsetBic { get; set; }

    [JsonProperty("reagDeagBic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64)]
    public string ReagDeagBic { get; set; }

    [JsonProperty("buyerSellBic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64)]
    public string BuyerSellBic { get; set; }

    [JsonProperty("memberAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64)]
    public string MemberAccountId { get; set; }

    [JsonProperty("safeKeepingAccountId", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    [StringLength(64)]
    public string SafeKeepingAccountId { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}