using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class FormW8IMY
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("countryOfIncorporation", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string CountryOfIncorporation { get; set; }

    [JsonProperty("disregardedEntityName", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public string DisregardedEntityName { get; set; }

    [JsonProperty("entityType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW8IMYEntityType EntityType { get; set; } = FormW8IMYEntityType.QUALIFIED_INTERMEDIARY;

    [JsonProperty("fatcaStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW8IMYFatcaStatus FatcaStatus { get; set; } = FormW8IMYFatcaStatus.NONPARTICIPATING_FFI;

    [JsonProperty("usTin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string UsTin { get; set; }

    [JsonProperty("usTinType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW8IMYUsTinType UsTinType { get; set; } = FormW8IMYUsTinType.QIEIN;

    [JsonProperty("giin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Giin { get; set; }

    [JsonProperty("referenceNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public int ReferenceNumber { get; set; }

    [JsonProperty("box11Status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public FormW8IMYBox11Status Box11Status { get; set; } = FormW8IMYBox11Status.LIMITED_BRANCH;

    [JsonProperty("part314A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314A { get; set; }

    [JsonProperty("part314B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314B { get; set; }

    [JsonProperty("part314C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314C { get; set; }

    [JsonProperty("part314CDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part314CDesc { get; set; }

    [JsonProperty("part314D", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314D { get; set; }

    [JsonProperty("part314DDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part314DDesc { get; set; }

    [JsonProperty("part314E", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314E { get; set; }

    [JsonProperty("part314EDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part314EDesc { get; set; }

    [JsonProperty("part314EI", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314EI { get; set; }

    [JsonProperty("part314EIi", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part314EIi { get; set; }

    [JsonProperty("part415A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part415A { get; set; }

    [JsonProperty("part415B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part415B { get; set; }

    [JsonProperty("part415C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part415C { get; set; }

    [JsonProperty("part415D", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part415D { get; set; }

    [JsonProperty("part516A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part516A { get; set; }

    [JsonProperty("part516B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part516B { get; set; }

    [JsonProperty("part516C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part516C { get; set; }

    [JsonProperty("part617A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part617A { get; set; }

    [JsonProperty("part617B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part617B { get; set; }

    [JsonProperty("part617C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part617C { get; set; }

    [JsonProperty("part718", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part718 { get; set; }

    [JsonProperty("part819", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part819 { get; set; }

    [JsonProperty("part920", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part920 { get; set; }

    [JsonProperty("part1021", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part1021 { get; set; }

    [JsonProperty("part1021A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part1021A { get; set; }

    [JsonProperty("part1021B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1021B { get; set; }

    [JsonProperty("part1021C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1021C { get; set; }

    [JsonProperty("part1122A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1122A { get; set; }

    [JsonProperty("part1122B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1122B { get; set; }

    [JsonProperty("part1122C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1122C { get; set; }

    [JsonProperty("part1223", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1223 { get; set; }

    [JsonProperty("part1324", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1324 { get; set; }

    [JsonProperty("part1425A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part1425A { get; set; }

    [JsonProperty("part1425B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1425B { get; set; }

    [JsonProperty("part1526", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1526 { get; set; }

    [JsonProperty("part1627A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1627A { get; set; }

    [JsonProperty("part1627B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1627B { get; set; }

    [JsonProperty("part1627C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1627C { get; set; }

    [JsonProperty("part1728", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1728 { get; set; }

    [JsonProperty("part1829", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1829 { get; set; }

    [JsonProperty("part1829Desc1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part1829Desc1 { get; set; }

    [JsonProperty("part1829Desc2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part1829Desc2 { get; set; }

    [JsonProperty("part1829Desc3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part1829Desc3 { get; set; }

    [JsonProperty("part1930A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1930A { get; set; }

    [JsonProperty("part1930B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1930B { get; set; }

    [JsonProperty("part1930C", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1930C { get; set; }

    [JsonProperty("part1930D", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1930D { get; set; }

    [JsonProperty("part1930E", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1930E { get; set; }

    [JsonProperty("part1930F", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part1930F { get; set; }

    [JsonProperty("part2031", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2031 { get; set; }

    [JsonProperty("part2132", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2132 { get; set; }

    [JsonProperty("part2132Desc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part2132Desc { get; set; }

    [JsonProperty("part2233", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2233 { get; set; }

    [JsonProperty("part2233Desc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part2233Desc { get; set; }

    [JsonProperty("part2334A", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2334A { get; set; }

    [JsonProperty("part2334ADesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part2334ADesc { get; set; }

    [JsonProperty("part2334B", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2334B { get; set; }

    [JsonProperty("part2334BDesc", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part2334BDesc { get; set; }

    [JsonProperty("part2435", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2435 { get; set; }

    [JsonProperty("part2536", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2536 { get; set; }

    [JsonProperty("part2637", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2637 { get; set; }

    [JsonProperty("part2738", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Part2738 { get; set; }

    [JsonProperty("part2739", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Part2739 { get; set; }

    [JsonProperty("cert", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public bool Cert { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}