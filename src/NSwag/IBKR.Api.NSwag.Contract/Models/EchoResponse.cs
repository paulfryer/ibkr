using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class EchoResponse
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("requestMethod", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public EchoResponseRequestMethod RequestMethod { get; set; } = EchoResponseRequestMethod.GET;


	[JsonProperty("securityPolicy", Required = Required.Always)]
	[Required(AllowEmptyStrings = true)]
	[JsonConverter(typeof(StringEnumConverter))]
	public EchoResponseSecurityPolicy SecurityPolicy { get; set; } = EchoResponseSecurityPolicy.HTTPS;


	[JsonProperty("queryParameters", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public object QueryParameters { get; set; } = null;


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
