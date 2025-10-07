using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IRAPrimaryBeneficiaryEntity
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Address Address { get; set; }

    [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("externalId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ExternalId { get; set; }

    [JsonProperty("ownershipPercentage", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public double OwnershipPercentage { get; set; }

    [JsonProperty("title", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Title Title { get; set; }

    [JsonProperty("relationship", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IRAPrimaryBeneficiaryEntityRelationship Relationship { get; set; } =
        IRAPrimaryBeneficiaryEntityRelationship.Brother;

    [JsonProperty("executor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Individual Executor { get; set; }

    [JsonProperty("executionDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTimeOffset ExecutionDate { get; set; } = default;

    [JsonProperty("articleOfWill", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string ArticleOfWill { get; set; }

    [JsonProperty("entityType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IRAPrimaryBeneficiaryEntityEntityType EntityType { get; set; } = IRAPrimaryBeneficiaryEntityEntityType.Trust;

    [JsonProperty("charityNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public string CharityNumber { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}