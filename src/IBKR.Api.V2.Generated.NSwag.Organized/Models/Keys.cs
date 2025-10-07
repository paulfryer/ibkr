using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Keys : Anonymous13
{
    [JsonProperty("n", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string N { get; set; }

    [JsonProperty("e", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string E { get; set; }
}