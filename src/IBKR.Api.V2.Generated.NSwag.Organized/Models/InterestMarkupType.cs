using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class InterestMarkupType
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("currency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public InterestMarkupTypeCurrency Currency { get; set; } = InterestMarkupTypeCurrency.USD;

	[JsonProperty("debitMarkup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double DebitMarkup { get; set; } = 0.0;

	[JsonProperty("ibDebitMarkup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double IbDebitMarkup { get; set; } = 0.0;

	[JsonProperty("creditMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double CreditMarkdown { get; set; } = 0.0;

	[JsonProperty("shortCreditMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double ShortCreditMarkdown { get; set; } = 0.0;

	[JsonProperty("shortCfdCreditMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double ShortCfdCreditMarkdown { get; set; } = 0.0;

	[JsonProperty("longCfdDebitMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double LongCfdDebitMarkdown { get; set; } = 0.0;

	[JsonProperty("shortIndexCfdCreditMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double ShortIndexCfdCreditMarkdown { get; set; } = 0.0;

	[JsonProperty("longIndexCfdDebitMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double LongIndexCfdDebitMarkdown { get; set; } = 0.0;

	[JsonProperty("shortFxCfdMarkup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double ShortFxCfdMarkup { get; set; } = 0.0;

	[JsonProperty("longFxCfdMarkdown", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public double LongFxCfdMarkdown { get; set; } = 0.0;

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
