using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class AccreditedInvestor
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("qualifiedPurchaser", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public QualifiedPurchaser QualifiedPurchaser { get; set; } = null;

	[JsonProperty("eligibleContractParticipant", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EligibleContractParticipant EligibleContractParticipant { get; set; } = null;

	[JsonProperty("signedBy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> SignedBy { get; set; } = null;

	[JsonProperty("accountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string AccountId { get; set; } = null;

	[JsonProperty("status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Status { get; set; } = false;

	[JsonProperty("signature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Signature { get; set; } = null;

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
