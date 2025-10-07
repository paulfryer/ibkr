using System;
using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
internal class JsonInheritanceAttribute : Attribute
{
	public string Key { get; }

	public System.Type Type { get; }

	public JsonInheritanceAttribute(string key, System.Type type)
	{
		Key = key;
		Type = type;
	}
}
