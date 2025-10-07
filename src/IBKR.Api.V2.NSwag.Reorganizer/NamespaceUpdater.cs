using System.Text.RegularExpressions;

namespace IBKR.Api.V2.NSwag.Reorganizer;

/// <summary>
/// Updates namespace declarations to match folder structure
/// </summary>
public class NamespaceUpdater
{
    private readonly string _projectRoot;

    public NamespaceUpdater(string projectRoot)
    {
        _projectRoot = projectRoot;
    }

    public async Task UpdateNamespaces()
    {
        Console.WriteLine("\n=== Namespace Updater ===\n");
        Console.WriteLine($"Project Root: {_projectRoot}\n");

        var folders = new[]
        {
            "Models",
            "Services",
            "Interfaces",
            "Clients",
            "Helpers"
        };

        int filesUpdated = 0;

        foreach (var folder in folders)
        {
            var folderPath = Path.Combine(_projectRoot, folder);
            if (!Directory.Exists(folderPath))
                continue;

            var files = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);
            Console.WriteLine($"Processing {folder}/ ({files.Length} files)");

            foreach (var file in files)
            {
                if (await UpdateFileNamespace(file, folder))
                    filesUpdated++;
            }
        }

        Console.WriteLine($"\n✅ Updated namespaces in {filesUpdated} files");
    }

    private async Task<bool> UpdateFileNamespace(string filePath, string folder)
    {
        var content = await File.ReadAllTextAsync(filePath);
        var originalContent = content;

        // Determine the target namespace based on folder
        var targetNamespace = folder switch
        {
            "Models" => "IBKR.Api.V2.Generated.NSwag.Models",
            "Services" => "IBKR.Api.V2.Generated.NSwag.Services",
            "Interfaces" => "IBKR.Api.V2.Generated.NSwag.Interfaces",
            "Clients" => "IBKR.Api.V2.Generated.NSwag.Clients",
            "Helpers" => "IBKR.Api.V2.Generated.NSwag.Helpers",
            _ => "IBKR.Api.V2.Generated.NSwag"
        };

        // Update namespace declaration (handle both old-style and new-style)
        // Old style: namespace IBKR.Api.V2.Generated.NSwag { ... }
        // New style: namespace IBKR.Api.V2.Generated.NSwag;
        content = Regex.Replace(
            content,
            @"namespace\s+IBKR\.Api\.V2\.Generated\.NSwag(?:\.[\w\.]+)?\s*[;{]",
            $"namespace {targetNamespace};",
            RegexOptions.Multiline
        );

        // Add using directives for cross-namespace references
        content = AddUsingDirectives(content, folder);

        // Fix ambiguous Type references (when both System.Type and Models.Type exist)
        if (folder == "Services" || folder == "Interfaces")
        {
            // Replace typeof(Type) with typeof(System.Type) to avoid ambiguity
            content = Regex.Replace(content, @"\btypeof\(Type\)", "typeof(System.Type)");

            // Replace parameter types: "Type?" or "Type " at end of parameter declaration
            // Match: "Type? paramName" or "Type paramName" in method signatures
            content = Regex.Replace(content, @"\bType\?(?=\s+\w+\s*[=,)])", "Models.Type?");
            content = Regex.Replace(content, @"\bType(?=\s+\w+\s*[=,)])", "Models.Type");
        }

        // Only write if content changed
        if (content != originalContent)
        {
            await File.WriteAllTextAsync(filePath, content);
            return true;
        }

        return false;
    }

    private string AddUsingDirectives(string content, string folder)
    {
        var usingsToAdd = new List<string>();

        // Services and Interfaces need Models
        if (folder == "Services" || folder == "Interfaces")
        {
            usingsToAdd.Add("using IBKR.Api.V2.Generated.NSwag.Models;");
        }

        // Services need Interfaces
        if (folder == "Services")
        {
            usingsToAdd.Add("using IBKR.Api.V2.Generated.NSwag.Interfaces;");
        }

        // Helpers need Models
        if (folder == "Helpers")
        {
            usingsToAdd.Add("using IBKR.Api.V2.Generated.NSwag.Models;");
        }

        // Clients need Models (for nested types)
        if (folder == "Clients")
        {
            usingsToAdd.Add("using IBKR.Api.V2.Generated.NSwag.Models;");
        }

        // Models need Helpers for JsonInheritanceConverter and DateFormatConverter
        if (folder == "Models")
        {
            if (content.Contains("JsonInheritanceConverter") || content.Contains("DateFormatConverter"))
            {
                usingsToAdd.Add("using IBKR.Api.V2.Generated.NSwag.Helpers;");
            }
        }

        if (usingsToAdd.Count == 0)
            return content;

        // Find where to insert usings (after existing usings or before namespace)
        var namespaceMatch = Regex.Match(content, @"^namespace\s+", RegexOptions.Multiline);
        if (!namespaceMatch.Success)
            return content;

        // Find the last using statement before the namespace
        var lastUsingMatch = Regex.Matches(content.Substring(0, namespaceMatch.Index), @"^using\s+.*?;", RegexOptions.Multiline)
            .Cast<Match>()
            .LastOrDefault();

        int insertPosition;
        string insertText;

        if (lastUsingMatch != null)
        {
            // Insert after last using
            insertPosition = lastUsingMatch.Index + lastUsingMatch.Length;
            insertText = "\n" + string.Join("\n", usingsToAdd);
        }
        else
        {
            // No usings found, insert before namespace with a blank line after
            insertPosition = namespaceMatch.Index;
            insertText = string.Join("\n", usingsToAdd) + "\n\n";
        }

        // Check if the usings already exist
        foreach (var usingDirective in usingsToAdd.ToList())
        {
            if (content.Contains(usingDirective))
            {
                usingsToAdd.Remove(usingDirective);
            }
        }

        if (usingsToAdd.Count == 0)
            return content;

        // Rebuild insert text with remaining usings
        if (lastUsingMatch != null)
        {
            insertText = "\n" + string.Join("\n", usingsToAdd);
        }
        else
        {
            insertText = string.Join("\n", usingsToAdd) + "\n\n";
        }

        return content.Insert(insertPosition, insertText);
    }
}
