using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using System.Text.Json;

namespace IBKR.Api.Generator;

/// <summary>
/// Fixes known issues in the IBKR OpenAPI specification to enable clean code generation.
/// See OPENAPI_ERRORS.md for detailed documentation of each fix.
/// </summary>
public class OpenApiSpecFixer
{
    private readonly OpenApiDocument _document;
    private int _fixesApplied = 0;

    public OpenApiSpecFixer(OpenApiDocument document)
    {
        _document = document;
    }

    public void ApplyAllFixes()
    {
        Console.WriteLine("\n=== Applying OpenAPI Spec Fixes ===\n");

        FixInvalidExtensions();
        FixPathParameterMismatches();
        FixQueryParametersMarkedAsPath();
        FixPhantomPathParameters();
        AddDiscriminatorsToPolymorphicTypes();
        Fix401ErrorResponses();
        FixTypeFormatMismatches();

        Console.WriteLine($"\n✓ Applied {_fixesApplied} fixes total\n");
    }

    /// <summary>
    /// Error #1: Remove invalid "extensions" properties from examples and path definitions.
    /// OpenAPI only allows vendor extensions prefixed with "x-".
    /// </summary>
    private void FixInvalidExtensions()
    {
        Console.WriteLine("Fixing invalid 'extensions' properties...");
        int fixes = 0;

        // Remove extensions from all request/response examples
        foreach (var path in _document.Paths)
        {
            foreach (var operation in path.Value.Operations.Values)
            {
                // Fix request body examples
                if (operation.RequestBody?.Content != null)
                {
                    foreach (var content in operation.RequestBody.Content.Values)
                    {
                        if (content.Examples != null)
                        {
                            foreach (var example in content.Examples.Values)
                            {
                                if (example.Extensions.ContainsKey("extensions"))
                                {
                                    example.Extensions.Remove("extensions");
                                    fixes++;
                                }
                            }
                        }
                    }
                }

                // Fix response examples
                foreach (var response in operation.Responses.Values)
                {
                    if (response.Content != null)
                    {
                        foreach (var content in response.Content.Values)
                        {
                            if (content.Examples != null)
                            {
                                foreach (var example in content.Examples.Values)
                                {
                                    if (example.Extensions.ContainsKey("extensions"))
                                    {
                                        example.Extensions.Remove("extensions");
                                        fixes++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine($"  ✓ Removed {fixes} invalid 'extensions' properties");
        _fixesApplied += fixes;
    }

    /// <summary>
    /// Errors #2, #3, #6: Fix path parameter name mismatches between path template and parameter definitions.
    /// </summary>
    private void FixPathParameterMismatches()
    {
        Console.WriteLine("Fixing path parameter mismatches...");
        int fixes = 0;

        // Fix #2: /fyi/notifications/{notificationID} -> {notificationId}
        if (_document.Paths.ContainsKey("/fyi/notifications/{notificationID}"))
        {
            var pathItem = _document.Paths["/fyi/notifications/{notificationID}"];
            _document.Paths.Remove("/fyi/notifications/{notificationID}");
            _document.Paths.Add("/fyi/notifications/{notificationId}", pathItem);
            Console.WriteLine("  ✓ Fixed /fyi/notifications/{notificationID} -> {notificationId}");
            fixes++;
        }

        // Fix #3: /gw/api/v1/enumerations/{enumerationType} parameter name mismatch
        if (_document.Paths.ContainsKey("/gw/api/v1/enumerations/{enumerationType}"))
        {
            var pathItem = _document.Paths["/gw/api/v1/enumerations/{enumerationType}"];
            if (pathItem.Operations.ContainsKey(OperationType.Get))
            {
                var operation = pathItem.Operations[OperationType.Get];
                var typeParam = operation.Parameters.FirstOrDefault(p => p.Name == "type");
                if (typeParam != null)
                {
                    typeParam.Name = "enumerationType";
                    typeParam.In = ParameterLocation.Path;
                    typeParam.Required = true;
                    Console.WriteLine("  ✓ Fixed /gw/api/v1/enumerations/{enumerationType} parameter name");
                    fixes++;
                }
            }
        }

        // Fix #6: /portfolio/{accountid}/position/{conid} -> {accountId}
        if (_document.Paths.ContainsKey("/portfolio/{accountid}/position/{conid}"))
        {
            var pathItem = _document.Paths["/portfolio/{accountid}/position/{conid}"];
            _document.Paths.Remove("/portfolio/{accountid}/position/{conid}");
            _document.Paths.Add("/portfolio/{accountId}/position/{conid}", pathItem);
            Console.WriteLine("  ✓ Fixed /portfolio/{accountid} -> {accountId}");
            fixes++;
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Error #5: Convert query parameters incorrectly marked as path parameters.
    /// /portfolio/{accountId}/positions/{pageId} has model, sort, direction, waitForSecDef marked as path params.
    /// Also ensure pageId parameter is required=true since it's a path parameter.
    /// </summary>
    private void FixQueryParametersMarkedAsPath()
    {
        Console.WriteLine("Fixing query parameters incorrectly marked as path...");
        int fixes = 0;

        if (_document.Paths.ContainsKey("/portfolio/{accountId}/positions/{pageId}"))
        {
            var pathItem = _document.Paths["/portfolio/{accountId}/positions/{pageId}"];
            if (pathItem.Operations.ContainsKey(OperationType.Get))
            {
                var operation = pathItem.Operations[OperationType.Get];

                // Fix query params incorrectly marked as path
                var queryParamNames = new[] { "model", "sort", "direction", "waitForSecDef" };

                foreach (var paramName in queryParamNames)
                {
                    var param = operation.Parameters.FirstOrDefault(p => p.Name == paramName);
                    if (param != null && param.In == ParameterLocation.Path)
                    {
                        param.In = ParameterLocation.Query;
                        param.Required = false; // Query params are optional by default
                        fixes++;
                    }
                }

                // Ensure all actual path parameters are required=true
                foreach (var param in operation.Parameters.Where(p => p.In == ParameterLocation.Path))
                {
                    if (!param.Required)
                    {
                        param.Required = true;
                        fixes++;
                    }
                }

                if (fixes > 0)
                {
                    Console.WriteLine($"  ✓ Fixed {fixes} parameter issues in /portfolio/{{accountId}}/positions/{{pageId}}");
                }
            }
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Error #4: Remove phantom "param0" path parameter from /pa/allperiods.
    /// </summary>
    private void FixPhantomPathParameters()
    {
        Console.WriteLine("Fixing phantom path parameters...");
        int fixes = 0;

        if (_document.Paths.ContainsKey("/pa/allperiods"))
        {
            var pathItem = _document.Paths["/pa/allperiods"];
            if (pathItem.Operations.ContainsKey(OperationType.Post))
            {
                var operation = pathItem.Operations[OperationType.Post];
                var param0 = operation.Parameters.FirstOrDefault(p => p.Name == "param0");
                if (param0 != null)
                {
                    operation.Parameters.Remove(param0);
                    Console.WriteLine("  ✓ Removed phantom 'param0' from /pa/allperiods");
                    fixes++;
                }
            }
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Warning #7: Add discriminators to polymorphic types using oneOf/anyOf.
    /// Required for proper runtime serialization/deserialization.
    /// </summary>
    private void AddDiscriminatorsToPolymorphicTypes()
    {
        Console.WriteLine("Adding discriminators to polymorphic types...");
        int fixes = 0;

        if (_document.Components?.Schemas == null)
            return;

        var polymorphicSchemas = new[]
        {
            "TradingInstrument",
            "tickleResponse"
        };

        foreach (var schemaName in polymorphicSchemas)
        {
            if (_document.Components.Schemas.ContainsKey(schemaName))
            {
                var schema = _document.Components.Schemas[schemaName];

                // Only add discriminator if schema has oneOf or anyOf and doesn't already have one
                if ((schema.OneOf?.Count > 0 || schema.AnyOf?.Count > 0) && schema.Discriminator == null)
                {
                    schema.Discriminator = new OpenApiDiscriminator
                    {
                        PropertyName = "type", // Standard discriminator property name
                        Mapping = new Dictionary<string, string>()
                    };

                    // Build mapping from oneOf/anyOf references
                    var refs = schema.OneOf?.Count > 0 ? schema.OneOf : schema.AnyOf;
                    if (refs != null)
                    {
                        foreach (var refSchema in refs)
                        {
                            if (refSchema.Reference != null)
                            {
                                var refId = refSchema.Reference.Id;
                                schema.Discriminator.Mapping[refId] = $"#/components/schemas/{refId}";
                            }
                        }
                    }

                    // Add discriminator property to schema and mark as required
                    if (schema.Properties == null)
                    {
                        schema.Properties = new Dictionary<string, OpenApiSchema>();
                    }

                    if (!schema.Properties.ContainsKey("type"))
                    {
                        schema.Properties["type"] = new OpenApiSchema
                        {
                            Type = "string",
                            Description = "Discriminator property for polymorphic type"
                        };
                    }

                    // Add to required list
                    if (schema.Required == null)
                    {
                        schema.Required = new HashSet<string>();
                    }

                    if (!schema.Required.Contains("type"))
                    {
                        schema.Required.Add("type");
                    }

                    Console.WriteLine($"  ✓ Added discriminator to {schemaName}");
                    fixes++;
                }
            }
        }

        _fixesApplied += fixes;
    }

    /// <summary>
    /// Warning #8: Add global 401 Unauthorized error response schema.
    /// </summary>
    private void Fix401ErrorResponses()
    {
        Console.WriteLine("Adding 401 error response schema...");

        if (_document.Components == null)
            _document.Components = new OpenApiComponents();

        if (_document.Components.Responses == null)
            _document.Components.Responses = new Dictionary<string, OpenApiResponse>();

        // Add global 401 response if it doesn't exist
        if (!_document.Components.Responses.ContainsKey("Unauthorized"))
        {
            _document.Components.Responses["Unauthorized"] = new OpenApiResponse
            {
                Description = "Unauthorized - Authentication is required and has failed or has not been provided",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["application/json"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = new Dictionary<string, OpenApiSchema>
                            {
                                ["error"] = new OpenApiSchema { Type = "string" },
                                ["message"] = new OpenApiSchema { Type = "string" }
                            }
                        }
                    }
                }
            };

            Console.WriteLine("  ✓ Added global Unauthorized (401) response schema");
            _fixesApplied++;
        }
    }

    /// <summary>
    /// Warning #9: Fix type/format mismatches where string has int32/int64 format.
    /// </summary>
    private void FixTypeFormatMismatches()
    {
        Console.WriteLine("Fixing type/format mismatches...");
        int fixes = 0;

        foreach (var path in _document.Paths.Values)
        {
            foreach (var operation in path.Operations.Values)
            {
                foreach (var parameter in operation.Parameters)
                {
                    // If parameter is type string with int32/int64 format, change to integer
                    if (parameter.Schema != null &&
                        parameter.Schema.Type == "string" &&
                        (parameter.Schema.Format == "int32" || parameter.Schema.Format == "int64"))
                    {
                        parameter.Schema.Type = "integer";
                        fixes++;
                    }
                }
            }
        }

        if (fixes > 0)
        {
            Console.WriteLine($"  ✓ Fixed {fixes} type/format mismatches");
        }

        _fixesApplied += fixes;
    }
}
