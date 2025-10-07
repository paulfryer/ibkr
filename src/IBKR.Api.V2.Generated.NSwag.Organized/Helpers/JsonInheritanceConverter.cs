using System.CodeDom.Compiler;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class JsonInheritanceConverter : JsonConverter
{
    internal static readonly string DefaultDiscriminatorName = "discriminator";

    [ThreadStatic] private static bool _isReading;

    [ThreadStatic] private static bool _isWriting;

    public JsonInheritanceConverter()
    {
        DiscriminatorName = DefaultDiscriminatorName;
    }

    public JsonInheritanceConverter(string discriminatorName)
    {
        DiscriminatorName = discriminatorName;
    }

    public string DiscriminatorName { get; }

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

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        try
        {
            _isWriting = true;
            var jObject = JObject.FromObject(value, serializer);
            jObject.AddFirst(new JProperty(DiscriminatorName, GetSubtypeDiscriminator(value.GetType())));
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

    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue,
        JsonSerializer serializer)
    {
        var jObject = serializer.Deserialize<JObject>(reader);
        if (jObject == null) return null;
        var discriminator = jObject.GetValue(DiscriminatorName)?.Value<string>();
        var objectSubtype = GetObjectSubtype(objectType, discriminator);
        if (!(serializer.ContractResolver.ResolveContract(objectSubtype) is JsonObjectContract jsonObjectContract) ||
            jsonObjectContract.Properties.All(p => p.PropertyName != DiscriminatorName))
            jObject.Remove(DiscriminatorName);
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
        foreach (var customAttribute in objectType.GetTypeInfo().GetCustomAttributes<JsonInheritanceAttribute>(true))
            if (customAttribute.Key == discriminator)
                return customAttribute.Type;
        return objectType;
    }

    private string GetSubtypeDiscriminator(System.Type objectType)
    {
        foreach (var customAttribute in objectType.GetTypeInfo().GetCustomAttributes<JsonInheritanceAttribute>(true))
            if (customAttribute.Type == objectType)
                return customAttribute.Key;
        return objectType.Name;
    }
}