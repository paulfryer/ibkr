using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IRABeneficiariesType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("primaryBeneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IRAPrimaryBeneficiary> PrimaryBeneficiaries { get; set; } = null;

	[JsonProperty("primaryBeneficiaryEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IRAPrimaryBeneficiaryEntity> PrimaryBeneficiaryEntities { get; set; } = null;

	[JsonProperty("contingentBeneficiaries", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IRAContingentBeneficiary> ContingentBeneficiaries { get; set; } = null;

	[JsonProperty("contingentBeneficiaryEntities", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<IRAContingentBeneficiaryEntity> ContingentBeneficiaryEntities { get; set; } = null;

	[JsonProperty("spousePrimaryBeneficary", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool SpousePrimaryBeneficary { get; set; } = false;

	[JsonProperty("successor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Successor { get; set; } = false;

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
