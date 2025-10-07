using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class StmtRequest
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountId", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string AccountId { get; set; } = null;


	[JsonProperty("accountIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> AccountIds { get; set; } = null;


	[JsonProperty("startDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string StartDate { get; set; } = null;


	[JsonProperty("endDate", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string EndDate { get; set; } = null;


	[JsonProperty("multiAccountFormat", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MultiAccountFormat { get; set; } = null;


	[JsonProperty("cryptoConsolIfAvailable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool CryptoConsolIfAvailable { get; set; } = false;


	[JsonProperty("mimeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string MimeType { get; set; } = null;


	[JsonProperty("language", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Language { get; set; } = "en";


	[JsonProperty("gzip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Gzip { get; set; } = false;


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
