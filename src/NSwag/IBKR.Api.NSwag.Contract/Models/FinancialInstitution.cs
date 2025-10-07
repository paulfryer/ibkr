using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FinancialInstitution
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("name", Required = Required.Always)]
	[Required]
	[StringLength(100, MinimumLength = 1)]
	public string Name { get; set; } = null;


	[JsonProperty("branchCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[StringLength(32)]
	public string BranchCode { get; set; } = null;


	[JsonProperty("branchCodeType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FinancialInstitutionBranchCodeType BranchCodeType { get; set; } = FinancialInstitutionBranchCodeType.BSB_AUD;


	[JsonProperty("identifier", Required = Required.Always)]
	[Required]
	[StringLength(24, MinimumLength = 1)]
	public string Identifier { get; set; } = null;


	[JsonProperty("identifierType", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FinancialInstitutionIdentifierType IdentifierType { get; set; } = FinancialInstitutionIdentifierType.BIC;


	[JsonProperty("clientAccountId", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string ClientAccountId { get; set; } = null;


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
