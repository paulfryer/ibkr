using System.Text;
using System.Text.RegularExpressions;

namespace IBKR.Api.Generator.NSwagReorganization;

/// <summary>
/// Generates service implementation classes by extracting methods from the monolithic IBKRClient
/// </summary>
public class ServiceImplementationGenerator
{
    private readonly string _sourceClientPath;
    private readonly string _interfacesDir;
    private readonly string _outputDir;

    public ServiceImplementationGenerator(string sourceClientPath, string interfacesDir, string outputDir)
    {
        _sourceClientPath = sourceClientPath;
        _interfacesDir = interfacesDir;
        _outputDir = outputDir;
    }

    public async Task GenerateServiceImplementations()
    {
        Console.WriteLine("\n=== Service Implementation Generator ===\n");
        Console.WriteLine($"Source: {Path.GetFileName(_sourceClientPath)}");
        Console.WriteLine($"Interfaces: {Path.GetFileName(_interfacesDir)}");
        Console.WriteLine($"Output: {_outputDir}\n");

        // Read the monolithic client
        var clientLines = await File.ReadAllLinesAsync(_sourceClientPath);
        var clientMethods = ParseClientMethods(clientLines);

        Console.WriteLine($"Parsed {clientMethods.Count} methods from IBKRClient");

        // Debug: Write method names to a file for inspection
        var debugPath = Path.Combine(Path.GetDirectoryName(_outputDir)!, "parsed_methods_debug.txt");
        await File.WriteAllLinesAsync(debugPath, clientMethods.Keys.OrderBy(k => k));
        Console.WriteLine($"Debug: Wrote parsed method names to {Path.GetFileName(debugPath)}\n");

        // Create output directory
        Directory.CreateDirectory(_outputDir);

        // Read all service interfaces
        var interfaceFiles = Directory.GetFiles(_interfacesDir, "I*Service.cs");
        int servicesGenerated = 0;

        foreach (var interfaceFile in interfaceFiles.OrderBy(f => f))
        {
            var serviceName = Path.GetFileNameWithoutExtension(interfaceFile).Substring(1); // Remove 'I' prefix
            var interfaceContent = await File.ReadAllLinesAsync(interfaceFile);
            var interfaceMethodNames = ParseInterfaceMethodNames(interfaceContent);

            if (interfaceMethodNames.Count > 0)
            {
                await GenerateServiceClass(serviceName, interfaceMethodNames, clientMethods);
                Console.WriteLine($"  ✓ {serviceName}: {interfaceMethodNames.Count} methods");
                servicesGenerated++;
            }
        }

        // Generate the composite IBKRClient wrapper
        await GenerateCompositeClient(interfaceFiles);

        Console.WriteLine($"\n✅ Generated {servicesGenerated} service implementations + composite client");
    }

    private Dictionary<string, MethodImplementation> ParseClientMethods(string[] lines)
    {
        var methods = new Dictionary<string, MethodImplementation>();
        var currentMethod = new StringBuilder();
        string? currentMethodName = null;
        int braceDepth = 0;
        bool inMethod = false;
        int methodStartLine = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            // Skip class declaration, fields, properties, constructors
            if (!inMethod)
            {
                // Look for async method signatures: public async Task< or public virtual async Task<
                if ((trimmed.StartsWith("public async Task<") || trimmed.StartsWith("public virtual async Task<") ||
                     trimmed.StartsWith("public Task<") || trimmed.StartsWith("public virtual Task<") ||
                     trimmed.StartsWith("public async System.Threading.Tasks.Task") ||
                     trimmed.StartsWith("public virtual async System.Threading.Tasks.Task") ||
                     trimmed.StartsWith("public System.Threading.Tasks.Task")) && trimmed.Contains("Async("))
                {
                    // Extract method name (handle virtual keyword and nested generics)
                    // Match the method name after "Task" and before "("
                    // Simple approach: find "Async(" and work backwards to get the method name
                    var asyncIndex = trimmed.IndexOf("Async(");
                    if (asyncIndex > 0)
                    {
                        // Work backwards from "Async(" to find the start of the method name
                        var beforeAsync = trimmed.Substring(0, asyncIndex + 5); // Include "Async"
                        var methodNameMatch = Regex.Match(beforeAsync, @"(\w+Async)$");
                        if (methodNameMatch.Success)
                        {
                            currentMethodName = methodNameMatch.Groups[1].Value;
                            inMethod = true;
                            braceDepth = 0;
                            methodStartLine = i;
                            currentMethod.Clear();
                            currentMethod.AppendLine(line);
                        }
                    }
                }
            }
            else
            {
                currentMethod.AppendLine(line);

                // Count braces
                foreach (char c in line)
                {
                    if (c == '{') braceDepth++;
                    else if (c == '}') braceDepth--;
                }

                // End of method
                if (braceDepth == 0 && trimmed == "}")
                {
                    if (currentMethodName != null)
                    {
                        methods[currentMethodName] = new MethodImplementation
                        {
                            Name = currentMethodName,
                            Code = currentMethod.ToString()
                        };
                    }
                    inMethod = false;
                    currentMethodName = null;
                }
            }
        }

        return methods;
    }

    private List<string> ParseInterfaceMethodNames(string[] lines)
    {
        var methodNames = new List<string>();

        foreach (var line in lines)
        {
            var trimmed = line.TrimStart();
            if ((trimmed.StartsWith("Task<") || trimmed.StartsWith("System.Threading.Tasks.Task ")) &&
                trimmed.Contains("Async("))
            {
                var match = Regex.Match(trimmed, @"(\w+Async)\(");
                if (match.Success)
                {
                    methodNames.Add(match.Groups[1].Value);
                }
            }
        }

        return methodNames;
    }

    private async Task GenerateServiceClass(string serviceName, List<string> methodNames, Dictionary<string, MethodImplementation> allMethods)
    {
        var sb = new StringBuilder();

        // Header
        sb.AppendLine("using System;");
        sb.AppendLine("using System.CodeDom.Compiler;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using System.Globalization;");
        sb.AppendLine("using System.IO;");
        sb.AppendLine("using System.Linq;");
        sb.AppendLine("using System.Net.Http;");
        sb.AppendLine("using System.Net.Http.Headers;");
        sb.AppendLine("using System.Runtime.Serialization;");
        sb.AppendLine("using System.Text;");
        sb.AppendLine("using System.Threading;");
        sb.AppendLine("using System.Threading.Tasks;");
        sb.AppendLine("using Newtonsoft.Json;");
        sb.AppendLine("using IBKR.Api.NSwag.Contract.Models;");
        sb.AppendLine("using IBKR.Api.NSwag.Contract.Interfaces;");
        sb.AppendLine();
        sb.AppendLine("namespace IBKR.Api.NSwag.Client.Services;");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Implementation of {serviceName}");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[GeneratedCode(\"NSwag\", \"14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))\")]");
        sb.AppendLine($"public partial class {serviceName} : I{serviceName}");
        sb.AppendLine("{");

        // Fields - use fully qualified type
        sb.AppendLine("\tprivate readonly System.Net.Http.HttpClient _httpClient;");
        sb.AppendLine("\tprivate readonly Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;");
        sb.AppendLine("\tprivate readonly string _baseUrl;");
        sb.AppendLine();

        // Constructor - use fully qualified type
        sb.AppendLine($"\tpublic {serviceName}(System.Net.Http.HttpClient httpClient)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\t_httpClient = httpClient;");
        sb.AppendLine("\t\t_settings = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);");
        sb.AppendLine("\t\t_baseUrl = \"https://api.ibkr.com\";");
        sb.AppendLine("\t}");
        sb.AppendLine();

        // JsonSerializerSettings property
        sb.AppendLine("\tprotected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings => _settings.Value;");
        sb.AppendLine();

        // CreateSerializerSettings method
        sb.AppendLine("\tprivate Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tvar settings = new Newtonsoft.Json.JsonSerializerSettings();");
        sb.AppendLine("\t\tUpdateJsonSerializerSettings(settings);");
        sb.AppendLine("\t\treturn settings;");
        sb.AppendLine("\t}");
        sb.AppendLine();

        // UpdateJsonSerializerSettings (partial method for customization)
        sb.AppendLine("\tpartial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);");
        sb.AppendLine();

        // Methods
        foreach (var methodName in methodNames.OrderBy(m => m))
        {
            if (allMethods.TryGetValue(methodName, out var method))
            {
                // Fix ambiguous type references in method code
                var fixedCode = FixAmbiguousTypesInCode(method.Code);
                sb.AppendLine(fixedCode);
            }
            else
            {
                Console.WriteLine($"    ⚠ Warning: Method {methodName} not found in IBKRClient");
            }
        }

        // Helper method stubs (will be shared across services)
        sb.AppendLine("\t// Helper methods from IBKRClient");
        sb.AppendLine("\tprotected struct ObjectResponseResult<T>");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tpublic T Object { get; }");
        sb.AppendLine("\t\tpublic string Text { get; }");
        sb.AppendLine("\t\tpublic ObjectResponseResult(T responseObject, string responseText)");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tObject = responseObject;");
        sb.AppendLine("\t\t\tText = responseText;");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t}");
        sb.AppendLine();

        sb.AppendLine("\tprotected string ConvertToString(object? value, CultureInfo cultureInfo)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tif (value == null) return \"\";");
        sb.AppendLine("\t\tif (value is Enum) return string.Format(cultureInfo, \"{0}\", Convert.ToInt32(value));");
        sb.AppendLine("\t\tif (value is bool b) return Convert.ToString(b, cultureInfo)?.ToLowerInvariant() ?? \"\";");
        sb.AppendLine("\t\tif (value is byte[] bytes) return Convert.ToBase64String(bytes);");
        sb.AppendLine("\t\treturn Convert.ToString(value, cultureInfo) ?? \"\";");
        sb.AppendLine("\t}");
        sb.AppendLine();

        sb.AppendLine("\tprotected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tif (response?.Content == null) return new ObjectResponseResult<T>(default(T), string.Empty);");
        sb.AppendLine("\t\tvar responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);");
        sb.AppendLine("\t\ttry");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tvar typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);");
        sb.AppendLine("\t\t\treturn new ObjectResponseResult<T>(typedBody, responseText);");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t\tcatch (JsonException exception)");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tvar message = \"Could not deserialize the response body string as \" + typeof(T).FullName + \".\";");
        sb.AppendLine("\t\t\tthrow new ApiException(message, (int)response.StatusCode, responseText, headers, exception);");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t}");
        sb.AppendLine();

        sb.AppendLine("}");

        // Write file
        var filePath = Path.Combine(_outputDir, $"{serviceName}.cs");
        await File.WriteAllTextAsync(filePath, sb.ToString());
    }

    private async Task GenerateCompositeClient(string[] interfaceFiles)
    {
        var sb = new StringBuilder();

        // Header
        sb.AppendLine("using System;");
        sb.AppendLine("using System.CodeDom.Compiler;");
        sb.AppendLine("using System.Net.Http;");
        sb.AppendLine("using IBKR.Api.NSwag.Contract.Interfaces;");
        sb.AppendLine();
        sb.AppendLine("namespace IBKR.Api.NSwag.Client.Services;");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine("/// Composite IBKR client providing access to all services");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[GeneratedCode(\"NSwag\", \"14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))\")]");
        sb.AppendLine("public class IBKRClient : IIBKRClient");
        sb.AppendLine("{");
        sb.AppendLine("\tprivate readonly System.Net.Http.HttpClient _httpClient;");
        sb.AppendLine();

        // Service fields and properties
        foreach (var interfaceFile in interfaceFiles.OrderBy(f => f))
        {
            var serviceName = Path.GetFileNameWithoutExtension(interfaceFile).Substring(1); // Remove 'I' prefix
            var propertyName = serviceName.Replace("Service", "");

            sb.AppendLine($"\tprivate readonly Lazy<{serviceName}> _{char.ToLower(propertyName[0])}{propertyName.Substring(1)};");
            sb.AppendLine($"\tpublic I{serviceName} {propertyName} => _{char.ToLower(propertyName[0])}{propertyName.Substring(1)}.Value;");
            sb.AppendLine();
        }

        // Constructor
        sb.AppendLine("\tpublic IBKRClient(HttpClient httpClient)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\t_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));");
        sb.AppendLine();

        foreach (var interfaceFile in interfaceFiles.OrderBy(f => f))
        {
            var serviceName = Path.GetFileNameWithoutExtension(interfaceFile).Substring(1);
            var propertyName = serviceName.Replace("Service", "");
            sb.AppendLine($"\t\t_{char.ToLower(propertyName[0])}{propertyName.Substring(1)} = new Lazy<{serviceName}>(() => new {serviceName}(_httpClient));");
        }

        sb.AppendLine("\t}");
        sb.AppendLine("}");

        // Write file
        var filePath = Path.Combine(_outputDir, "IBKRClient.cs");
        await File.WriteAllTextAsync(filePath, sb.ToString());
        Console.WriteLine($"\n  ✓ IBKRClient: Composite client with lazy service initialization");
    }

    private string FixAmbiguousTypesInCode(string code)
    {
        // Fix ambiguous Type references - need to use fully qualified since we also have System.Type
        code = System.Text.RegularExpressions.Regex.Replace(
            code,
            @"\bType([\?\s,>])",  // Type + (? or space or comma or >) but NOT preceded by Models.
            "IBKR.Api.NSwag.Contract.Models.Type$1"  // Replace with fully qualified type
        );

        // Fix bare "HttpClient" references to use fully qualified type
        code = System.Text.RegularExpressions.Regex.Replace(
            code,
            @"\b(HttpClient)\s+(\w+)",  // HttpClient followed by variable name
            "System.Net.Http.HttpClient $2"  // Replace with fully qualified type
        );

        return code;
    }

    private class MethodImplementation
    {
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
