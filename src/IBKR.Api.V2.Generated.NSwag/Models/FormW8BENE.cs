using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormW8BENE
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("substantialUsOwnerExternalIds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> SubstantialUsOwnerExternalIds { get; set; } = null;


	[JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; } = null;


	[JsonProperty("countryOfOrganization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string CountryOfOrganization { get; set; } = null;


	[JsonProperty("disregardedEntityName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string DisregardedEntityName { get; set; } = null;


	[JsonProperty("entityType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENEEntityType EntityType { get; set; } = FormW8BENEEntityType.CORPORATION;


	[JsonProperty("fatcaStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENEFatcaStatus FatcaStatus { get; set; } = FormW8BENEFatcaStatus.NONPARTICIPATING_FFI;


	[JsonProperty("usTin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string UsTin { get; set; } = null;


	[JsonProperty("giin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Giin { get; set; } = null;


	[JsonProperty("foreignTin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ForeignTin { get; set; } = null;


	[JsonProperty("tinOrExplanationRequired", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool TinOrExplanationRequired { get; set; } = false;


	[JsonProperty("explanation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENEExplanation Explanation { get; set; } = FormW8BENEExplanation.US_TIN;


	[JsonProperty("referenceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ReferenceNumber { get; set; } = 0;


	[JsonProperty("submitDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string SubmitDate { get; set; } = null;


	[JsonProperty("box11Status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENEBox11Status Box11Status { get; set; } = FormW8BENEBox11Status.LIMITED_BRANCH;


	[JsonProperty("part314A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part314A { get; set; } = false;


	[JsonProperty("part314ACountry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part314ACountry { get; set; } = null;


	[JsonProperty("part314B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENEPart314B Part314B { get; set; } = FormW8BENEPart314B.CompanyMeetsOwnershipAndBaseErosionTest;


	[JsonProperty("part314C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part314C { get; set; } = false;


	[JsonProperty("part416", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part416 { get; set; } = null;


	[JsonProperty("part417I", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part417I { get; set; } = false;


	[JsonProperty("part417Ii", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part417Ii { get; set; } = false;


	[JsonProperty("part518", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part518 { get; set; } = false;


	[JsonProperty("part619", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part619 { get; set; } = false;


	[JsonProperty("part720", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part720 { get; set; } = null;


	[JsonProperty("part721", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part721 { get; set; } = false;


	[JsonProperty("part822", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part822 { get; set; } = false;


	[JsonProperty("part923", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part923 { get; set; } = false;


	[JsonProperty("part1024A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1024A { get; set; } = false;


	[JsonProperty("part1024B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1024B { get; set; } = false;


	[JsonProperty("part1024C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1024C { get; set; } = false;


	[JsonProperty("part1024D", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1024D { get; set; } = false;


	[JsonProperty("part1125A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1125A { get; set; } = false;


	[JsonProperty("part1125B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1125B { get; set; } = false;


	[JsonProperty("part1125C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1125C { get; set; } = false;


	[JsonProperty("part1226", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1226 { get; set; } = false;


	[JsonProperty("part1226Desc1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part1226Desc1 { get; set; } = null;


	[JsonProperty("part1226Desc2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part1226Desc2 { get; set; } = null;


	[JsonProperty("part1226Desc3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENEPart1226Desc3 Part1226Desc3 { get; set; } = FormW8BENEPart1226Desc3.CollectiveInvestmentVehicle;


	[JsonProperty("part1226Desc4", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part1226Desc4 { get; set; } = null;


	[JsonProperty("part1327", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1327 { get; set; } = false;


	[JsonProperty("part1428A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1428A { get; set; } = false;


	[JsonProperty("part1428B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1428B { get; set; } = false;


	[JsonProperty("part1529A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1529A { get; set; } = false;


	[JsonProperty("part1529B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1529B { get; set; } = false;


	[JsonProperty("part1529C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1529C { get; set; } = false;


	[JsonProperty("part1529D", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1529D { get; set; } = false;


	[JsonProperty("part1529E", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1529E { get; set; } = false;


	[JsonProperty("part1529F", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1529F { get; set; } = false;


	[JsonProperty("part1630", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1630 { get; set; } = false;


	[JsonProperty("part1731", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1731 { get; set; } = false;


	[JsonProperty("part1832", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1832 { get; set; } = false;


	[JsonProperty("part1933", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part1933 { get; set; } = false;


	[JsonProperty("part2034", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2034 { get; set; } = false;


	[JsonProperty("part2135", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2135 { get; set; } = false;


	[JsonProperty("part2135Date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part2135Date { get; set; } = null;


	[JsonProperty("part2236", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2236 { get; set; } = false;


	[JsonProperty("part2337A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2337A { get; set; } = false;


	[JsonProperty("part2337ADesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part2337ADesc { get; set; } = null;


	[JsonProperty("part2337B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2337B { get; set; } = false;


	[JsonProperty("part2337BDesc1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part2337BDesc1 { get; set; } = null;


	[JsonProperty("part2337BDesc2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part2337BDesc2 { get; set; } = null;


	[JsonProperty("part2438", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2438 { get; set; } = false;


	[JsonProperty("part2539", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2539 { get; set; } = false;


	[JsonProperty("part2640A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2640A { get; set; } = false;


	[JsonProperty("part2640B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2640B { get; set; } = false;


	[JsonProperty("part2640C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2640C { get; set; } = false;


	[JsonProperty("part2741", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2741 { get; set; } = false;


	[JsonProperty("part2842", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Part2842 { get; set; } = null;


	[JsonProperty("part2843", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Part2843 { get; set; } = false;


	[JsonProperty("cert", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool Cert { get; set; } = false;


	[JsonProperty("signatureType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public FormW8BENESignatureType SignatureType { get; set; } = FormW8BENESignatureType.Electronic;


	[JsonProperty("blankForm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool BlankForm { get; set; } = false;


	[JsonProperty("taxFormFile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string TaxFormFile { get; set; } = null;


	[JsonProperty("proprietaryFormNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public int ProprietaryFormNumber { get; set; } = 0;


	[JsonProperty("electronicFormat", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ElectronicFormat { get; set; } = false;


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
