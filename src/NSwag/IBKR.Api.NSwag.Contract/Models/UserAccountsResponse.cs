using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class UserAccountsResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accounts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Accounts { get; set; } = null;


	[JsonProperty("acctProps", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AcctProps AcctProps { get; set; } = null;


	[JsonProperty("aliases", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Aliases Aliases { get; set; } = null;


	[JsonProperty("allowFeatures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AllowFeatures AllowFeatures { get; set; } = null;


	[JsonProperty("chartPeriods", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ChartPeriods ChartPeriods { get; set; } = null;


	[JsonProperty("groups", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Groups { get; set; } = null;


	[JsonProperty("profiles", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> Profiles { get; set; } = null;


	[JsonProperty("selectedAccount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SelectedAccount { get; set; } = null;


	[JsonProperty("serverInfo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ServerInfo2 ServerInfo { get; set; } = null;


	[JsonProperty("sessionId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SessionId { get; set; } = null;


	[JsonProperty("isFt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsFt { get; set; } = false;


	[JsonProperty("isPaper", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool IsPaper { get; set; } = false;


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
