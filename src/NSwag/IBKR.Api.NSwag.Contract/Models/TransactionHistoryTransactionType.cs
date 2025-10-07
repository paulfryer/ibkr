using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IBKR.Api.NSwag.Contract.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public enum TransactionHistoryTransactionType
{
	[EnumMember(Value = "ALL")]
	ALL,
	[EnumMember(Value = "ACH_INSTRUCTION")]
	ACH_INSTRUCTION,
	[EnumMember(Value = "PREDEFINED_DESTINATION_INSTRUCTION")]
	PREDEFINED_DESTINATION_INSTRUCTION,
	[EnumMember(Value = "WITHDRAWAL")]
	WITHDRAWAL,
	[EnumMember(Value = "DEPOSIT")]
	DEPOSIT,
	[EnumMember(Value = "DWAC")]
	DWAC,
	[EnumMember(Value = "FOP")]
	FOP,
	[EnumMember(Value = "EDDA_INSTRUCTION")]
	EDDA_INSTRUCTION,
	[EnumMember(Value = "TRADITIONAL_BANK_INSTRUCTION_VERIFICATION")]
	TRADITIONAL_BANK_INSTRUCTION_VERIFICATION,
	[EnumMember(Value = "CANCEL_INSTRUCTION")]
	CANCEL_INSTRUCTION,
	[EnumMember(Value = "DELETE_BANK_INSTRUCTION")]
	DELETE_BANK_INSTRUCTION,
	[EnumMember(Value = "EXTERNAL_POSITION_TRANSFER")]
	EXTERNAL_POSITION_TRANSFER,
	[EnumMember(Value = "INTERNAL_CASH_TRANSFER")]
	INTERNAL_CASH_TRANSFER,
	[EnumMember(Value = "INTERNAL_POSITION_TRANSFER")]
	INTERNAL_POSITION_TRANSFER,
	[EnumMember(Value = "COMPLEX_ASSET_TRANSFER")]
	COMPLEX_ASSET_TRANSFER
}
