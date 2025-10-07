using System.CodeDom.Compiler;
using Newtonsoft.Json.Converters;
using IBKR.Api.NSwag.Contract.Models;

namespace IBKR.Api.NSwag.Contract.Helpers;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
internal class DateFormatConverter : IsoDateTimeConverter
{
	public DateFormatConverter()
	{
		base.DateTimeFormat = "yyyy-MM-dd";
	}
}
