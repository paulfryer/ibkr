using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IBKR.Api.NSwag.Contract.Helpers;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class Document
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("signedBy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ICollection<string> SignedBy { get; set; } = null;


	[JsonProperty("attachedFile", Required = Required.Always)]
	[Required]
	public AttachedFileType AttachedFile { get; set; } = new AttachedFileType();


	[JsonProperty("formNumber", Required = Required.Always)]
	public int FormNumber { get; set; } = 0;


	[JsonProperty("validAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public bool ValidAddress { get; set; } = false;


	[JsonProperty("execLoginTimestamp", Required = Required.Always)]
	public int ExecLoginTimestamp { get; set; } = 0;


	[JsonProperty("execTimestamp", Required = Required.Always)]
	public int ExecTimestamp { get; set; } = 0;


	[JsonProperty("documentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DocumentType DocumentType { get; set; } = DocumentType.Check;


	[JsonProperty("signature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string Signature { get; set; } = null;


	[JsonProperty("externalAccountId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalAccountId { get; set; } = null;


	[JsonProperty("externalIndividualId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public string ExternalIndividualId { get; set; } = null;


	[JsonProperty("proofOfIdentityType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DocumentProofOfIdentityType ProofOfIdentityType { get; set; } = DocumentProofOfIdentityType.Driver_License;


	[JsonProperty("expirationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(DateFormatConverter))]
	public DateTimeOffset ExpirationDate { get; set; } = default(DateTimeOffset);


	[JsonProperty("proofOfAddressType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	[JsonConverter(typeof(StringEnumConverter))]
	public DocumentProofOfAddressType ProofOfAddressType { get; set; } = DocumentProofOfAddressType.Driver_License;


	[JsonProperty("payload", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FilePayload Payload { get; set; } = null;


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
