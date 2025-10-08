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
}
