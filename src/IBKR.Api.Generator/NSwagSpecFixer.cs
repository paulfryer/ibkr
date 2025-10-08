using Microsoft.OpenApi.Models;

namespace IBKR.Api.Generator;

/// <summary>
/// Fixes NSwag-specific issues in the IBKR OpenAPI specification.
/// </summary>
public class NSwagSpecFixer
{
    private readonly OpenApiDocument _document;
    private int _fixesApplied = 0;

    public NSwagSpecFixer(OpenApiDocument document)
    {
        _document = document;
    }

    public void ApplyAllFixes()
    {
        Console.WriteLine("\n=== Applying NSwag-Specific OpenAPI Spec Fixes ===\n");

        FixDefaultServerUrl();
        FixRestrictedFieldType();
        FixSnapshotResponseType();
        // FixSecDefInfoResponseType(); // DISABLED: Causes NSwag to drop the endpoint entirely
        FixSearchResultRequiredFields();
        FixContractInfoRequiredFields();
        FixSecDefInfoRequiredFields();

        Console.WriteLine($"\n✓ Applied {_fixesApplied} NSwag-specific fixes total\n");
    }

    /// <summary>
    /// Prepend /v1/api to paths that have per-endpoint server overrides.
    ///
    /// IBKR's OpenAPI spec has:
    /// - Top-level servers: ["https://api.ibkr.com", "https://qa.interactivebrokers.com"]
    /// - Per-endpoint server overrides: Many endpoints override with "https://api.ibkr.com/v1/api"
    ///
    /// NSwag uses the top-level server and ignores per-endpoint overrides. Instead of changing
    /// the server URL (which breaks IBKRAuthenticationProvider), we prepend /v1/api to the
    /// paths themselves for endpoints that have the server override.
    ///
    /// For example:
    /// - Path "/iserver/account" with server override "https://api.ibkr.com/v1/api"
    ///   becomes "/v1/api/iserver/account" with server "https://api.ibkr.com"
    /// </summary>
    private void FixDefaultServerUrl()
    {
        Console.WriteLine("Prepending /v1/api to paths with per-endpoint server overrides...");
        int fixes = 0;

        var pathsToUpdate = new Dictionary<string, string>(); // old path -> new path

        foreach (var path in _document.Paths)
        {
            // Check if any operation in this path has a server override
            foreach (var operation in path.Value.Operations.Values)
            {
                if (operation.Servers != null && operation.Servers.Count > 0)
                {
                    // Check if the operation has a /v1/api server override
                    var hasV1ApiServer = operation.Servers.Any(s =>
                        s.Url.Contains("/v1/api") || s.Url.Contains("/alpha/api"));

                    if (hasV1ApiServer && !path.Key.StartsWith("/v1/api") && !path.Key.StartsWith("/alpha/api"))
                    {
                        // Determine which prefix to use based on the server
                        var prefix = operation.Servers.First(s => s.Url.Contains("/v1/api") || s.Url.Contains("/alpha/api"))
                            .Url.Contains("/alpha/api") ? "/alpha/api" : "/v1/api";

                        var newPath = prefix + path.Key;
                        pathsToUpdate[path.Key] = newPath;

                        // Clear the server override since we're now including the prefix in the path
                        operation.Servers = null;

                        break; // Only need to check one operation per path
                    }
                }
            }
        }

        // Update the paths
        foreach (var update in pathsToUpdate)
        {
            var pathItem = _document.Paths[update.Key];
            _document.Paths.Remove(update.Key);
            _document.Paths.Add(update.Value, pathItem);
            fixes++;
        }

        if (fixes > 0)
        {
            Console.WriteLine($"  ✓ Prepended /v1/api to {fixes} paths");
        }
        else
        {
            Console.WriteLine("  ⚠ No paths found to fix");
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Fix the /iserver/secdef/info response type from single object to array.
    ///
    /// IBKR's API returns an array of option contract details: [{...}, {...}]
    /// but the OpenAPI spec defines the response as a single SecDefInfoResponse object.
    /// This causes deserialization errors in NSwag.
    ///
    /// Location: paths/"/iserver/secdef/info"/get/responses/200/content/application/json/schema
    /// Change: { "$ref": "#/components/schemas/secDefInfoResponse" } → { "type": "array", "items": { "$ref": "#/components/schemas/secDefInfoResponse" } }
    /// </summary>
    private void FixSecDefInfoResponseType()
    {
        Console.WriteLine("Fixing /iserver/secdef/info response type from object to array...");
        int fixes = 0;

        // Find the secdef/info endpoint - could be at different paths depending on whether FixDefaultServerUrl has run
        var possiblePaths = new[] { "/iserver/secdef/info", "/v1/api/iserver/secdef/info" };

        foreach (var pathKey in possiblePaths)
        {
            if (_document.Paths.ContainsKey(pathKey))
            {
                var pathItem = _document.Paths[pathKey];

                if (pathItem.Operations.ContainsKey(OperationType.Get))
                {
                    var operation = pathItem.Operations[OperationType.Get];

                    if (operation.Responses.ContainsKey("200"))
                    {
                        var response = operation.Responses["200"];

                        if (response.Content?.ContainsKey("application/json") == true)
                        {
                            var mediaType = response.Content["application/json"];

                            // Check if it's currently a single object reference to secDefInfoResponse
                            if (mediaType.Schema?.Reference != null &&
                                mediaType.Schema.Reference.Id.Replace("-", "").Replace("_", "")
                                    .Equals("secdefInforesponse", StringComparison.OrdinalIgnoreCase))
                            {
                                // Replace with array of secDefInfoResponse
                                var arraySchema = new OpenApiSchema
                                {
                                    Type = "array",
                                    Items = new OpenApiSchema
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.Schema,
                                            Id = mediaType.Schema.Reference.Id // Use the exact ID from the spec
                                        }
                                    }
                                };

                                mediaType.Schema = arraySchema;
                                fixes++;
                                Console.WriteLine($"  ✓ Changed response type to array at {pathKey}");
                            }
                        }
                    }
                }
            }
        }

        if (fixes == 0)
        {
            Console.WriteLine("  ⚠ Could not find secdef/info endpoint to fix");
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Fix the 'restricted' field type from boolean to string.
    ///
    /// IBKR's API returns string values like "CFD,IOPT,WAR" for the restricted field,
    /// but the OpenAPI spec defines it as boolean. This causes deserialization errors in NSwag.
    ///
    /// Location: components/schemas/secdefSearchResponse (array) -> items -> properties -> restricted
    /// Change: type: boolean → type: string
    /// </summary>
    private void FixRestrictedFieldType()
    {
        Console.WriteLine("Fixing 'restricted' field type from boolean to string...");
        int fixes = 0;

        if (_document.Components?.Schemas != null)
        {
            // Find the secdefSearchResponse schema
            var schemaKey = _document.Components.Schemas.Keys
                .FirstOrDefault(k => k.Equals("secdefSearchResponse", StringComparison.OrdinalIgnoreCase));

            if (schemaKey != null)
            {
                var schema = _document.Components.Schemas[schemaKey];

                // secdefSearchResponse is an array, so the properties are in the items
                if (schema.Type == "array" && schema.Items != null)
                {
                    if (schema.Items.Properties != null && schema.Items.Properties.ContainsKey("restricted"))
                    {
                        var restrictedProperty = schema.Items.Properties["restricted"];

                        // Change type from boolean to string
                        if (restrictedProperty.Type == "boolean")
                        {
                            restrictedProperty.Type = "string";
                            fixes++;
                            Console.WriteLine($"  ✓ Changed 'restricted' field from boolean to string in {schemaKey} items");
                        }
                    }
                }
                // Fallback: check if it's directly on the schema (shouldn't be, but just in case)
                else if (schema.Properties != null && schema.Properties.ContainsKey("restricted"))
                {
                    var restrictedProperty = schema.Properties["restricted"];

                    // Change type from boolean to string
                    if (restrictedProperty.Type == "boolean")
                    {
                        restrictedProperty.Type = "string";
                        fixes++;
                        Console.WriteLine($"  ✓ Changed 'restricted' field from boolean to string in {schemaKey}");
                    }
                }
            }
        }

        if (fixes == 0)
        {
            Console.WriteLine("  ⚠ Could not find 'restricted' field to fix");
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Fix the /iserver/marketdata/snapshot response type from single object to array.
    ///
    /// IBKR's API returns an array of market data objects: [{...}]
    /// but the OpenAPI spec defines the response as a single fyiVT object.
    /// This causes deserialization errors in NSwag.
    ///
    /// Location: paths/"/iserver/marketdata/snapshot"/get/responses/200/content/application/json/schema
    /// Change: { "$ref": "#/components/schemas/fyiVT" } → { "type": "array", "items": { "$ref": "#/components/schemas/fyiVT" } }
    /// </summary>
    private void FixSnapshotResponseType()
    {
        Console.WriteLine("Fixing /iserver/marketdata/snapshot response type from object to array...");
        int fixes = 0;

        // Find the snapshot endpoint - could be at different paths depending on whether FixDefaultServerUrl has run
        var possiblePaths = new[] { "/iserver/marketdata/snapshot", "/v1/api/iserver/marketdata/snapshot" };

        foreach (var pathKey in possiblePaths)
        {
            if (_document.Paths.ContainsKey(pathKey))
            {
                var pathItem = _document.Paths[pathKey];

                if (pathItem.Operations.ContainsKey(OperationType.Get))
                {
                    var operation = pathItem.Operations[OperationType.Get];

                    if (operation.Responses.ContainsKey("200"))
                    {
                        var response = operation.Responses["200"];

                        if (response.Content?.ContainsKey("application/json") == true)
                        {
                            var mediaType = response.Content["application/json"];

                            // Check if it's currently a single object reference
                            if (mediaType.Schema?.Reference != null &&
                                mediaType.Schema.Reference.Id.Equals("fyiVT", StringComparison.OrdinalIgnoreCase))
                            {
                                // Replace with array of fyiVT
                                var arraySchema = new OpenApiSchema
                                {
                                    Type = "array",
                                    Items = new OpenApiSchema
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.Schema,
                                            Id = "fyiVT"
                                        }
                                    }
                                };

                                mediaType.Schema = arraySchema;
                                fixes++;
                                Console.WriteLine($"  ✓ Changed response type to array at {pathKey}");
                            }
                        }
                    }
                }
            }
        }

        if (fixes == 0)
        {
            Console.WriteLine("  ⚠ Could not find snapshot endpoint to fix");
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Make companyName, companyHeader, and description optional in search results.
    ///
    /// IBKR's /iserver/secdef/search API returns an array of mixed results:
    /// - Stock/ETF results have companyName, companyHeader, description
    /// - Option/Derivative results often have these fields as null or missing
    ///
    /// The OpenAPI spec marks these as required, causing NSwag to generate [Required]
    /// attributes which fail deserialization when the API returns null values.
    ///
    /// Location: components/schemas/secdefSearchResponse (array) -> items -> required
    /// Change: Remove companyName/companyHeader/description from required array
    /// </summary>
    private void FixSearchResultRequiredFields()
    {
        Console.WriteLine("Making companyName/companyHeader/description optional in search results...");
        int fixes = 0;

        if (_document.Components?.Schemas != null)
        {
            // Find the secdefSearchResponse schema
            var schemaKey = _document.Components.Schemas.Keys
                .FirstOrDefault(k => k.Equals("secdefSearchResponse", StringComparison.OrdinalIgnoreCase));

            if (schemaKey != null)
            {
                var schema = _document.Components.Schemas[schemaKey];

                // secdefSearchResponse is an array, so the properties are in the items
                if (schema.Type == "array" && schema.Items != null)
                {
                    // Fields that are inconsistent in real API responses
                    // Some items (stocks/ETFs) have these fields, others (derivatives/warrants) don't
                    var fieldsToMakeOptional = new[] { "companyName", "companyHeader", "description", "symbol" };

                    foreach (var field in fieldsToMakeOptional)
                    {
                        // Remove from required array
                        if (schema.Items.Required?.Contains(field) == true)
                        {
                            schema.Items.Required.Remove(field);
                            fixes++;
                            Console.WriteLine($"  ✓ Made '{field}' optional in {schemaKey} items");
                        }

                        // Mark property as nullable
                        if (schema.Items.Properties?.ContainsKey(field) == true)
                        {
                            schema.Items.Properties[field].Nullable = true;
                        }
                    }
                }
            }
        }

        if (fixes == 0)
        {
            Console.WriteLine("  ⚠ Could not find search result schema to fix");
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Make cusip and other optional fields in ContractInfo schema.
    ///
    /// IBKR's /iserver/contract/{conid}/info API returns contract details where
    /// many fields can be null depending on the security type:
    /// - cusip: null for non-US securities
    /// - Other fields may also be null
    ///
    /// Location: components/schemas/contract (or similar)
    /// Change: Remove cusip from required array and mark as nullable
    /// </summary>
    private void FixContractInfoRequiredFields()
    {
        Console.WriteLine("Making cusip optional in ContractInfo...");
        int fixes = 0;

        if (_document.Components?.Schemas != null)
        {
            // Find the contract info schema - could be named "contract", "ContractInfo", etc.
            foreach (var schemaEntry in _document.Components.Schemas)
            {
                var schema = schemaEntry.Value;

                // Look for schema with cusip property
                if (schema.Properties?.ContainsKey("cusip") == true)
                {
                    Console.WriteLine($"  Found schema with cusip: {schemaEntry.Key}");

                    // Fields that can be null in real API responses
                    // Many fields are null for stocks (vs options/futures)
                    var fieldsToMakeOptional = new[] {
                        "cusip",
                        "expiry_full",
                        "maturity_date",
                        "contract_clarification_type",
                        "classifier",
                        "text",
                        "multiplier",
                        "underlying_issuer",
                        "contract_month"
                    };

                    foreach (var field in fieldsToMakeOptional)
                    {
                        // Remove from required array
                        if (schema.Required?.Contains(field) == true)
                        {
                            schema.Required.Remove(field);
                            fixes++;
                            Console.WriteLine($"  ✓ Made '{field}' optional in {schemaEntry.Key}");
                        }

                        // Mark property as nullable
                        if (schema.Properties?.ContainsKey(field) == true)
                        {
                            schema.Properties[field].Nullable = true;
                        }
                    }
                }
            }
        }

        if (fixes == 0)
        {
            Console.WriteLine("  ⚠ Could not find contract info schema to fix");
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Make listingExchange and other fields optional in SecDefInfoResponse.
    ///
    /// IBKR's option contract detail API returns option contracts where:
    /// - listingExchange: null for many options
    /// - companyName: null for options (only stocks have company names)
    /// - Other fields may also be null
    ///
    /// Location: components/schemas/secdef-info-response
    /// Change: Remove fields from required array and mark as nullable
    /// </summary>
    private void FixSecDefInfoRequiredFields()
    {
        Console.WriteLine("Making listingExchange/companyName optional in SecDefInfoResponse...");
        int fixes = 0;

        if (_document.Components?.Schemas != null)
        {
            // Find the SecDefInfoResponse schema - could be named with different cases
            var schemaKey = _document.Components.Schemas.Keys
                .FirstOrDefault(k => k.Replace("-", "").Replace("_", "")
                    .Equals("secdefInforesponse", StringComparison.OrdinalIgnoreCase));

            if (schemaKey != null)
            {
                var schema = _document.Components.Schemas[schemaKey];

                Console.WriteLine($"  Found schema: {schemaKey}");

                // Fields that can be null in real API responses
                // Options don't have company names, listingExchange can be null
                var fieldsToMakeOptional = new[] {
                    "listingExchange",
                    "companyName"
                };

                foreach (var field in fieldsToMakeOptional)
                {
                    // Remove from required array
                    if (schema.Required?.Contains(field) == true)
                    {
                        schema.Required.Remove(field);
                        fixes++;
                        Console.WriteLine($"  ✓ Made '{field}' optional in {schemaKey}");
                    }

                    // Mark property as nullable
                    if (schema.Properties?.ContainsKey(field) == true)
                    {
                        schema.Properties[field].Nullable = true;
                    }
                }
            }
        }

        if (fixes == 0)
        {
            Console.WriteLine("  ⚠ Could not find SecDefInfoResponse schema to fix");
        }

        _fixesApplied += fixes;
    }
}
