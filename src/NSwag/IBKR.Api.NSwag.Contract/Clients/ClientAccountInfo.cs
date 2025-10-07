using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Clients;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class ClientAccountInfo
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("bankRoutingNumber", Required = Required.Always)]
	[Required]
	[StringLength(24, MinimumLength = 1)]
	public string BankRoutingNumber { get; set; } = null;


	[JsonProperty("bankAccountNumber", Required = Required.Always)]
	[Required]
	[StringLength(32, MinimumLength = 1)]
	public string BankAccountNumber { get; set; } = null;


	[JsonProperty("bankName", Required = Required.Always)]
	[Required]
	[StringLength(100, MinimumLength = 1)]
	public string BankName { get; set; } = null;


	[JsonProperty("bankAccountTypeCode", Required = Required.Always)]
	public double BankAccountTypeCode { get; set; } = 0.0;


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
