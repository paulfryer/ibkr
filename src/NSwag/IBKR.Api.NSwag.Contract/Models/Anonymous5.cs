using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Anonymous5
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("bondid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int Bondid { get; set; } = 0;


	[JsonProperty("conid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Conid { get; set; } = null;


	[JsonProperty("companyHeader", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CompanyHeader { get; set; } = null;


	[JsonProperty("companyName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CompanyName { get; set; } = null;


	[JsonProperty("symbol", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } = null;


	[JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Description { get; set; } = null;


	[JsonProperty("restricted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public bool? Restricted { get; set; } = null;


	[JsonProperty("fop", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? Fop { get; set; } = null;


	[JsonProperty("opt", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? Opt { get; set; } = null;


	[JsonProperty("war", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
	public string? War { get; set; } = null;


	[JsonProperty("sections", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Sections> Sections { get; set; } = null;


	[JsonProperty("issuers", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<Issuers> Issuers { get; set; } = null;


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
