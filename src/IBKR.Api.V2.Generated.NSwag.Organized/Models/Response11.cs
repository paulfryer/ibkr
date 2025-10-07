using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Response11 : ContractInfo
{
	[JsonProperty("rules", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ContractRules Rules { get; set; } = null;
}
