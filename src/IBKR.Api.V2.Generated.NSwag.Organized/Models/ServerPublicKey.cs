using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ServerPublicKey
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("keyId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string KeyId { get; set; } = null;

	[JsonProperty("keyBitSize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[Range(3072, int.MaxValue)]
	public int KeyBitSize { get; set; } = 0;

	[JsonProperty("symmetric", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Symmetric { get; set; } = false;

	[JsonProperty("public", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Public { get; set; } = false;

	[JsonProperty("private", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Private { get; set; } = false;

	[JsonProperty("asymmetric", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Asymmetric { get; set; } = false;

	[JsonProperty("empty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Empty { get; set; } = false;

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
