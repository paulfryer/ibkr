namespace IBKR.Api.V2.Generator;

/// <summary>
/// Applies post-generation fixes specifically for NSwag-generated projects.
/// These fixes address known issues with NSwag's code generation for the IBKR OpenAPI spec.
/// </summary>
public class NSwagProjectFixer
{
    private readonly string _projectDir;
    private readonly string _projectFile;

    public NSwagProjectFixer(string projectDir, string projectFile)
    {
        _projectDir = projectDir;
        _projectFile = projectFile;
    }

    public async Task ApplyAllFixes()
    {
        Console.WriteLine("\n=== Applying NSwag Post-Generation Fixes ===\n");

        await AddNewtonsoftJsonDependency();
        await RemoveDuplicateGeneratedCodeAttributes();
        await FixPhantomTypeReferences();
        // File splitting disabled for now - works as monolithic file
        // await SplitMonolithicFileIntoSeparateFiles();

        Console.WriteLine("\n✓ NSwag post-generation fixes complete\n");
    }

    /// <summary>
    /// Fix #1: NSwag generates code that uses Newtonsoft.Json but doesn't add the package reference.
    /// This causes ~6,000 compilation errors: CS0246: The type or namespace name 'Newtonsoft' could not be found
    /// </summary>
    private async Task AddNewtonsoftJsonDependency()
    {
        Console.WriteLine("Adding Newtonsoft.Json package dependency...");

        // Read current .csproj
        var csprojContent = await File.ReadAllTextAsync(_projectFile);

        // Check if Newtonsoft.Json is already referenced
        if (csprojContent.Contains("Newtonsoft.Json"))
        {
            Console.WriteLine("  ℹ Newtonsoft.Json already referenced");
            return;
        }

        // Add Newtonsoft.Json package reference
        var updatedContent = csprojContent.Replace(
            "</PropertyGroup>",
            @"</PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Newtonsoft.Json"" Version=""13.0.4"" />
  </ItemGroup>");

        await File.WriteAllTextAsync(_projectFile, updatedContent);

        Console.WriteLine("  ✓ Added Newtonsoft.Json v13.0.4 package reference");
    }

    /// <summary>
    /// Fix #2: NSwag generates duplicate [GeneratedCode] attributes on partial interfaces/classes
    /// when the OpenAPI spec has polymorphic types. This causes ~5,000+ CS0579 compilation errors.
    /// Solution: Remove duplicate [System.CodeDom.Compiler.GeneratedCode] attributes from partial types.
    /// </summary>
    private async Task RemoveDuplicateGeneratedCodeAttributes()
    {
        Console.WriteLine("Removing duplicate [GeneratedCode] attributes from partial types...");

        var clientFile = Path.Combine(_projectDir, "IBKRClient.cs");
        if (!File.Exists(clientFile))
        {
            Console.WriteLine("  ⚠ IBKRClient.cs not found, skipping fix");
            return;
        }

        var lines = await File.ReadAllLinesAsync(clientFile);
        var fixedLines = new List<string>();
        var seenPartialTypes = new HashSet<string>();
        int attributesRemoved = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            // Check if this is a GeneratedCode attribute line
            if (trimmed.StartsWith("[System.CodeDom.Compiler.GeneratedCode("))
            {
                // Look ahead to see what it's decorating
                if (i + 1 < lines.Length)
                {
                    var nextLine = lines[i + 1].TrimStart();

                    // Check if it's a partial interface or partial class
                    if (nextLine.StartsWith("public partial interface ") ||
                        nextLine.StartsWith("public partial class "))
                    {
                        var typeName = ExtractTypeName(nextLine);

                        // If we've already seen this partial type, skip the attribute
                        if (seenPartialTypes.Contains(typeName))
                        {
                            attributesRemoved++;
                            continue; // Skip adding this attribute line
                        }
                        else
                        {
                            seenPartialTypes.Add(typeName);
                        }
                    }
                }
            }

            fixedLines.Add(line);
        }

        if (attributesRemoved > 0)
        {
            await File.WriteAllLinesAsync(clientFile, fixedLines);
            Console.WriteLine($"  ✓ Removed {attributesRemoved} duplicate [GeneratedCode] attributes");
        }
        else
        {
            Console.WriteLine("  ℹ No duplicate attributes found");
        }
    }

    private string ExtractTypeName(string line)
    {
        // Extract type name from "public partial interface IFoo" or "public partial class Foo"
        var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length >= 4)
        {
            return parts[3]; // "public" "partial" "interface/class" "TypeName"
        }
        return line;
    }

    /// <summary>
    /// Fix #3: NSwag generates phantom type references for polymorphic types.
    /// Example: References TradingInstrument2 but only defines TradingInstrument.
    /// This causes CS0246 compilation errors for missing types.
    /// Solution: Replace phantom type names with actual type names.
    /// </summary>
    private async Task FixPhantomTypeReferences()
    {
        Console.WriteLine("Fixing phantom type references...");

        var clientFile = Path.Combine(_projectDir, "IBKRClient.cs");
        if (!File.Exists(clientFile))
        {
            Console.WriteLine("  ⚠ IBKRClient.cs not found, skipping fix");
            return;
        }

        var content = await File.ReadAllTextAsync(clientFile);
        var originalContent = content;

        // Fix: TradingInstrument2 -> TradingInstrument
        content = content.Replace("TradingInstrument2", "TradingInstrument");

        // Could add more phantom type fixes here as needed
        // content = content.Replace("OtherPhantomType2", "OtherPhantomType");

        if (content != originalContent)
        {
            await File.WriteAllTextAsync(clientFile, content);
            Console.WriteLine("  ✓ Fixed phantom type references (TradingInstrument2 → TradingInstrument)");
        }
        else
        {
            Console.WriteLine("  ℹ No phantom type references found");
        }
    }

    /// <summary>
    /// Fix #4: Split the monolithic IBKRClient.cs file into separate files (one per class/interface/enum).
    /// This mimics Kiota's multi-file output and makes the codebase more maintainable.
    /// Idempotent: Can run multiple times - will clean up and recreate files each time.
    /// </summary>
    private async Task SplitMonolithicFileIntoSeparateFiles()
    {
        Console.WriteLine("Splitting monolithic file into separate files...");

        var clientFile = Path.Combine(_projectDir, "IBKRClient.cs");
        if (!File.Exists(clientFile))
        {
            Console.WriteLine("  ⚠ IBKRClient.cs not found, skipping split");
            return;
        }

        // Create subdirectories for organization
        var modelsDir = Path.Combine(_projectDir, "Models");
        var clientsDir = Path.Combine(_projectDir, "Clients");

        // Clean up old split files (idempotent - remove previous split)
        if (Directory.Exists(modelsDir))
        {
            Directory.Delete(modelsDir, recursive: true);
        }
        if (Directory.Exists(clientsDir))
        {
            Directory.Delete(clientsDir, recursive: true);
        }

        Directory.CreateDirectory(modelsDir);
        Directory.CreateDirectory(clientsDir);

        var lines = await File.ReadAllLinesAsync(clientFile);

        // FIRST: Extract helper classes from IBKRClient before we do anything else
        await CreateHelpersFile(lines);

        // SECOND: Parse the file and extract types (models, enums, etc.)
        var extractedTypes = ExtractTypes(lines);

        Console.WriteLine($"  Found {extractedTypes.Count} types to extract");

        int filesCreated = 0;
        foreach (var type in extractedTypes)
        {
            var targetDir = type.IsClient ? clientsDir : modelsDir;
            var targetFile = Path.Combine(targetDir, $"{type.Name}.cs");

            await File.WriteAllLinesAsync(targetFile, type.Lines);
            filesCreated++;
        }

        Console.WriteLine($"  ✓ Split into {filesCreated} files ({Path.GetFileName(modelsDir)}/, {Path.GetFileName(clientsDir)}/)");

        // THIRD: Replace the monolithic file with just the IBKRClient class (no models)
        await CreateSlimClientFile(lines);
    }

    private class ExtractedType
    {
        public string Name { get; set; } = "";
        public List<string> Lines { get; set; } = new();
        public bool IsClient { get; set; }
    }

    private List<ExtractedType> ExtractTypes(string[] lines)
    {
        var types = new List<ExtractedType>();
        var namespaceLines = new List<string>();
        var usingLines = new List<string>();

        // Collect using statements and namespace declaration
        bool inNamespace = false;
        int namespaceIndentLevel = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            if (trimmed.StartsWith("using ") && !inNamespace)
            {
                usingLines.Add(line);
            }
            else if (trimmed.StartsWith("namespace "))
            {
                namespaceLines.Add(line);
                inNamespace = true;
                namespaceIndentLevel = line.TakeWhile(c => c == ' ').Count();
            }
            else if (inNamespace && trimmed.StartsWith("{") && namespaceLines.Count > 0)
            {
                namespaceLines.Add(line);
                break; // Found namespace opening brace, we have what we need
            }
        }

        // Now extract types
        ExtractedType? currentType = null;
        int braceDepth = 0;
        bool insideType = false;
        int typeStartIndent = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            // Skip usings and namespace declaration (we'll add them to each file)
            if (trimmed.StartsWith("using ") || trimmed.StartsWith("namespace ") ||
                (trimmed == "{" && !insideType))
            {
                continue;
            }

            // Check for type declaration
            if (!insideType && (trimmed.StartsWith("public partial class ") ||
                                trimmed.StartsWith("public class ") ||
                                trimmed.StartsWith("public partial interface ") ||
                                trimmed.StartsWith("public interface ") ||
                                trimmed.StartsWith("public enum ") ||
                                trimmed.StartsWith("public partial struct ") ||
                                trimmed.StartsWith("public struct ")))
            {
                // Extract type name
                var typeName = ExtractTypeNameFromDeclaration(trimmed);

                currentType = new ExtractedType
                {
                    Name = typeName,
                    IsClient = typeName.Contains("Client") && !typeName.Contains("Http")
                };

                // Add file header
                currentType.Lines.AddRange(usingLines);
                currentType.Lines.Add("");
                currentType.Lines.AddRange(namespaceLines);

                // Add any attributes before the type declaration
                int attrIndex = i - 1;
                var attributes = new List<string>();
                while (attrIndex >= 0)
                {
                    var attrLine = lines[attrIndex].TrimStart();
                    if (attrLine.StartsWith("[") || string.IsNullOrWhiteSpace(attrLine))
                    {
                        if (attrLine.StartsWith("["))
                        {
                            attributes.Insert(0, lines[attrIndex]);
                        }
                        attrIndex--;
                    }
                    else
                    {
                        break;
                    }
                }

                currentType.Lines.AddRange(attributes);
                insideType = true;
                braceDepth = 0;
                typeStartIndent = line.TakeWhile(c => c == ' ').Count();
            }

            if (insideType && currentType != null)
            {
                currentType.Lines.Add(line);

                // Track braces
                foreach (char c in line)
                {
                    if (c == '{') braceDepth++;
                    else if (c == '}') braceDepth--;
                }

                // Check if we've closed the type definition
                if (braceDepth == 0 && trimmed == "}")
                {
                    // Add namespace closing brace
                    currentType.Lines.Add("}");

                    types.Add(currentType);
                    currentType = null;
                    insideType = false;
                }
            }
        }

        return types;
    }

    private string ExtractTypeNameFromDeclaration(string declaration)
    {
        // Extract type name from declarations like:
        // "public partial class Foo : IBar"
        // "public class Foo<T>"
        // "public interface IFoo"
        // "public enum MyEnum"

        var parts = declaration.Split(new[] { ' ', ':', '<', '{' }, StringSplitOptions.RemoveEmptyEntries);

        // Find the type name (comes after "class", "interface", "enum", or "struct")
        for (int i = 0; i < parts.Length - 1; i++)
        {
            if (parts[i] == "class" || parts[i] == "interface" ||
                parts[i] == "enum" || parts[i] == "struct")
            {
                return parts[i + 1];
            }
        }

        return "UnknownType";
    }

    private async Task CreateSlimClientFile(string[] lines)
    {
        // Create a new IBKRClient.cs that contains ONLY the IBKRClient class definition
        // (methods, properties, constructors) without any model classes

        var clientFile = Path.Combine(_projectDir, "IBKRClient.cs");
        var slimLines = new List<string>();

        // Track what we're including
        bool insideIBKRClient = false;
        bool insideModelType = false;
        int braceDepth = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            // Always include using statements and namespace
            if (trimmed.StartsWith("using ") || trimmed.StartsWith("namespace "))
            {
                slimLines.Add(line);
                continue;
            }

            // Include namespace opening brace
            if (trimmed == "{" && !insideIBKRClient && !insideModelType && slimLines.Count > 0 &&
                slimLines[slimLines.Count - 1].TrimStart().StartsWith("namespace "))
            {
                slimLines.Add(line);
                continue;
            }

            // Check if we're entering the IBKRClient class
            if (!insideIBKRClient &&
                (trimmed.StartsWith("public partial class IBKRClient") || trimmed.StartsWith("public class IBKRClient")))
            {
                insideIBKRClient = true;
                braceDepth = 0;
                slimLines.Add(line);
                continue;
            }

            if (insideIBKRClient)
            {
                // Track braces
                int bracesInLine = line.Count(c => c == '{') - line.Count(c => c == '}');

                // Skip orphaned attributes (attributes without following type definitions)
                if (trimmed.StartsWith("[") && !insideModelType)
                {
                    // Look ahead to see if there's a type definition after this attribute
                    bool hasFollowingType = false;
                    for (int j = i + 1; j < Math.Min(i + 5, lines.Length); j++)
                    {
                        var nextTrimmed = lines[j].TrimStart();
                        if (string.IsNullOrWhiteSpace(nextTrimmed) || nextTrimmed.StartsWith("["))
                        {
                            continue;
                        }
                        if (nextTrimmed.StartsWith("public ") || nextTrimmed.StartsWith("private ") ||
                            nextTrimmed.StartsWith("internal "))
                        {
                            hasFollowingType = true;
                        }
                        break;
                    }

                    // If no following type, skip this orphaned attribute
                    if (!hasFollowingType)
                    {
                        continue;
                    }
                }

                // Check if this is a model type definition (not a method or property)
                if (!insideModelType && braceDepth == 0 &&
                    (trimmed.StartsWith("public partial class ") ||
                     trimmed.StartsWith("public class ") ||
                     trimmed.StartsWith("public enum ") ||
                     trimmed.StartsWith("public interface ") ||
                     trimmed.StartsWith("public struct ")) &&
                    !trimmed.Contains("IBKRClient") &&
                    !trimmed.StartsWith("public partial class ObjectResponseResult") &&
                    !trimmed.StartsWith("private class ") &&
                    !trimmed.StartsWith("internal class "))
                {
                    // This is a model type - skip it
                    insideModelType = true;
                    braceDepth = 0;
                }

                if (!insideModelType)
                {
                    slimLines.Add(line);
                }

                braceDepth += bracesInLine;

                // Exit model type when braces close
                if (insideModelType && braceDepth == 0 && trimmed == "}")
                {
                    insideModelType = false;
                }

                // Exit IBKRClient when fully closed
                if (!insideModelType && braceDepth < 0)
                {
                    insideIBKRClient = false;
                }
            }
            else if (!insideModelType)
            {
                // Outside IBKRClient, include namespace closing, etc.
                if (trimmed == "}")
                {
                    slimLines.Add(line);
                }
            }
        }

        // Clean up: remove trailing orphaned attributes and extra blank lines at the end
        while (slimLines.Count > 1) // Keep at least the closing brace
        {
            var lastLine = slimLines[slimLines.Count - 1];
            var trimmed = lastLine.Trim();

            if (string.IsNullOrWhiteSpace(trimmed) ||
                trimmed.StartsWith("[System.CodeDom.Compiler.GeneratedCode") ||
                trimmed.StartsWith("[System.Runtime.Serialization"))
            {
                slimLines.RemoveAt(slimLines.Count - 1);
            }
            else
            {
                break; // Stop when we hit actual code or closing brace
            }
        }

        // Ensure we end with the namespace closing brace
        if (slimLines.Count > 0 && slimLines[slimLines.Count - 1].TrimStart() != "}")
        {
            slimLines.Add("}");
        }

        await File.WriteAllLinesAsync(clientFile, slimLines);
        Console.WriteLine($"  ✓ Created slim IBKRClient.cs (client methods only, no models)");
    }

    private async Task CreateHelpersFile(string[] lines)
    {
        // Extract helper classes that are nested or not captured by the main extraction
        // These include things like DateFormatConverter, nested classes within IBKRClient, etc.

        var helpersFile = Path.Combine(_projectDir, "IBKRHelpers.cs");
        var helperLines = new List<string>();

        // Get using statements and namespace
        var usingLines = new List<string>();
        var namespaceLines = new List<string>();

        for (int i = 0; i < lines.Length && i < 100; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            if (trimmed.StartsWith("using "))
            {
                usingLines.Add(line);
            }
            else if (trimmed.StartsWith("namespace "))
            {
                namespaceLines.Add(line);
            }
            else if (namespaceLines.Count > 0 && trimmed == "{")
            {
                namespaceLines.Add(line);
                break;
            }
        }

        helperLines.AddRange(usingLines);
        helperLines.Add("");
        helperLines.AddRange(namespaceLines);

        // Find all nested helper classes within IBKRClient
        bool insideIBKRClient = false;
        int braceDepth = 0;
        int clientBraceLevel = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var trimmed = line.TrimStart();

            // Track when we enter the IBKRClient class
            if (!insideIBKRClient && (trimmed.StartsWith("public partial class IBKRClient") ||
                                       trimmed.StartsWith("public class IBKRClient")))
            {
                insideIBKRClient = true;
                braceDepth = 0;
                continue;
            }

            if (insideIBKRClient)
            {
                // Track braces
                foreach (char c in line)
                {
                    if (c == '{') braceDepth++;
                    else if (c == '}') braceDepth--;
                }

                // Save client brace level when we first enter
                if (clientBraceLevel == 0 && braceDepth > 0)
                {
                    clientBraceLevel = braceDepth;
                }

                // Look for nested classes (ObjectResponseResult, DateFormatConverter, etc.)
                if (braceDepth > clientBraceLevel &&
                    (trimmed.StartsWith("private class ") ||
                     trimmed.StartsWith("internal class ") ||
                     trimmed.StartsWith("public class ") ||
                     trimmed.StartsWith("private struct ") ||
                     trimmed.StartsWith("internal struct ")))
                {
                    var nestedTypeName = ExtractTypeNameFromDeclaration(trimmed);

                    {
                        // Extract this nested class
                        int nestedStart = i;
                        int nestedBraceDepth = 0;
                        List<string> nestedClass = new List<string>();

                        // Capture any attributes
                        int attrIndex = i - 1;
                        while (attrIndex >= 0 && lines[attrIndex].TrimStart().StartsWith("["))
                        {
                            nestedClass.Insert(0, lines[attrIndex]);
                            attrIndex--;
                        }

                        // Capture the class itself
                        for (int j = i; j < lines.Length; j++)
                        {
                            nestedClass.Add(lines[j]);

                            foreach (char c in lines[j])
                            {
                                if (c == '{') nestedBraceDepth++;
                                else if (c == '}') nestedBraceDepth--;
                            }

                            if (nestedBraceDepth == 0 && lines[j].TrimStart() == "}")
                            {
                                helperLines.AddRange(nestedClass);
                                helperLines.Add("");
                                i = j; // Skip ahead
                                break;
                            }
                        }
                    }
                }

                // Exit when we close the IBKRClient class
                if (braceDepth == 0 && trimmed == "}")
                {
                    break;
                }
            }
        }

        // Close namespace
        helperLines.Add("}");

        if (helperLines.Count > usingLines.Count + namespaceLines.Count + 2)
        {
            await File.WriteAllLinesAsync(helpersFile, helperLines);
            Console.WriteLine($"  ✓ Created helpers file: {Path.GetFileName(helpersFile)}");
        }
    }
}
