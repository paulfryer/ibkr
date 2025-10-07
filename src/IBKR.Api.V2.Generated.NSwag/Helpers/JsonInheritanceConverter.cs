using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using IBKR.Api.V2.Generated.NSwag.Models;

namespace IBKR.Api.V2.Generated.NSwag.Helpers;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class JsonInheritanceConverter : JsonConverter
{
	internal static readonly string DefaultDiscriminatorName = "discriminator";

	private readonly string _discriminatorName;

	[ThreadStatic]
	private static bool _isReading;

	[ThreadStatic]
	private static bool _isWriting;

	public string DiscriminatorName => _discriminatorName;

	public override bool CanWrite
	{
		get
		{
			if (_isWriting)
			{
				_isWriting = false;
				return false;
			}
			return true;
		}
	}

	public override bool CanRead
	{
		get
		{
			if (_isReading)
			{
				_isReading = false;
				return false;
			}
			return true;
		}
	}

	public JsonInheritanceConverter()
	{
		_discriminatorName = DefaultDiscriminatorName;
	}

	public JsonInheritanceConverter(string discriminatorName)
	{
		_discriminatorName = discriminatorName;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		try
		{
			_isWriting = true;
			JObject jObject = JObject.FromObject(value, serializer);
			jObject.AddFirst(new JProperty(_discriminatorName, GetSubtypeDiscriminator(value.GetType())));
			writer.WriteToken(jObject.CreateReader());
		}
		finally
		{
			_isWriting = false;
		}
	}

	public override bool CanConvert(System.Type objectType)
	{
		return true;
	}

	public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
	{
		JObject jObject = serializer.Deserialize<JObject>(reader);
		if (jObject == null)
		{
			return null;
		}
		string discriminator = jObject.GetValue(_discriminatorName)?.Value<string>();
		System.Type objectSubtype = GetObjectSubtype(objectType, discriminator);
		if (!(serializer.ContractResolver.ResolveContract(objectSubtype) is JsonObjectContract jsonObjectContract) || ((IEnumerable<JsonProperty>)jsonObjectContract.Properties).All((JsonProperty p) => p.PropertyName != _discriminatorName))
		{
			jObject.Remove(_discriminatorName);
		}
		try
		{
			_isReading = true;
			return serializer.Deserialize(jObject.CreateReader(), objectSubtype);
		}
		finally
		{
			_isReading = false;
		}
	}

	private System.Type GetObjectSubtype(System.Type objectType, string discriminator)
	{
		foreach (JsonInheritanceAttribute customAttribute in objectType.GetTypeInfo().GetCustomAttributes<JsonInheritanceAttribute>(inherit: true))
		{
			if (customAttribute.Key == discriminator)
			{
				return customAttribute.Type;
			}
		}
		return objectType;
	}

	private string GetSubtypeDiscriminator(System.Type objectType)
	{
		foreach (JsonInheritanceAttribute customAttribute in objectType.GetTypeInfo().GetCustomAttributes<JsonInheritanceAttribute>(inherit: true))
		{
			if (customAttribute.Type == objectType)
			{
				return customAttribute.Key;
			}
		}
		return objectType.Name;
	}
}
