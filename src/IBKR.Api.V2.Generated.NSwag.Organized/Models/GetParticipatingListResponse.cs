using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class GetParticipatingListResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("type", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	public string Type { get; set; } = null;

	[JsonProperty("participatingBanks", Required = Required.Always)]
	[Required]
	public ICollection<ParticipatingBanks> ParticipatingBanks { get; set; } = new Collection<ParticipatingBanks>();

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
