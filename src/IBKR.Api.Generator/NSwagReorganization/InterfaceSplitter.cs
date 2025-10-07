using System.Text;

namespace IBKR.Api.Generator.NSwagReorganization;

/// <summary>
/// Splits the monolithic IIBKRClient interface into service-based interfaces
/// based on the structure discovered by Kiota generator
/// </summary>
public class InterfaceSplitter
{
    private readonly string _sourceInterfacePath;
    private readonly string _outputDir;

    // Service mapping based on Kiota's natural decomposition
    private static readonly Dictionary<string, List<string>> ServiceMapping = new()
    {
        ["Acesws"] = new() { "SignaturesAndOwnersAsync" },

        ["Fyi"] = new() {
            "DeliveryoptionsGETAsync", "DeliveryoptionsDELETEAsync", "DeviceAsync", "EmailAsync",
            "DisclaimerGETAsync", "DisclaimerPUTAsync", "NotificationsAllAsync", "NotificationsAsync",
            "SettingsAllAsync", "SettingsAsync", "UnreadnumberAsync"
        },

        ["Gw"] = new() {
            "AccountsGETAsync", "AccountsPOSTAsync", "AccountsPATCHAsync", "DocumentsAsync",
            "LoginMessagesAsync", "LoginMessages2Async", "StatusGETAsync", "StatusGET2Async", "StatusGET3Async",
            "DetailsAsync", "KycAsync", "TasksAsync", "BankInstructionsAsync",
            "ComplexAssetTransferAsync", "EnumerationsAsync", "ExternalAssetTransfersAsync",
            "ExternalCashTransfersAsync", "FormsAsync", "InstructionSetsAsync", "InstructionsAsync",
            "InternalAssetTransfersAsync", "InternalCashTransfersAsync", "ParticipatingBanksAsync",
            "QueryAsync", "Query2Async", "Query3Async", "RequestsAsync",
            "SsoBrowserSessionsAsync", "SsoSessionsAsync", "StatementsAsync", "AvailableAsync",
            "TaxDocumentsAsync", "Available2Async", "TradeConfirmationsAsync", "Available3Async",
            "UsernamesAsync", "CancelAsync", "ClientInstructionsAsync", "HttpsAsync", "SignedJwtAsync"
        },

        ["Hmds"] = new() {
            "HistoryAsync", "ParamsAsync", "RunAsync"
        },

        ["Iserver"] = new() {
            "AccountAsync", "AccountsGET2Async", "AccountsGET3Async", "InitAsync", "StatusPOSTAsync",
            "RulesAsync", "AlgosAsync", "InfoAsync", "InfoAndRulesAsync", "PairsAsync",
            "DynaccountAsync", "ExchangerateAsync", "History2Async", "SnapshotAsync",
            "UnsubscribeAsync", "UnsubscribeallAsync", "NotificationAsync", "SuppressAsync",
            "ResetAsync", "ReauthenticateAsync", "ReplyAsync", "Params2Async", "Run2Async",
            "BondFiltersAsync", "Info2Async", "SearchAllGETAsync", "SearchAllPOSTAsync", "StrikesAsync",
            "WatchlistGETAsync", "WatchlistPOSTAsync", "WatchlistDELETEAsync", "WatchlistsAsync",
            "AlertGETAsync", "AlertPOSTAsync", "AlertDELETEAsync", "AlertsAsync", "ActivateAsync",
            "GroupGETAsync", "GroupPUTAsync", "GroupPOSTAsync", "DeleteAsync", "SingleAsync",
            "PresetsGETAsync", "PresetsPOSTAsync", "MtaAsync", "OrderPOSTAsync", "OrderDELETEAsync",
            "OrdersPOSTAsync", "OrdersGETAsync", "StatusGET4Async", "WhatifAsync", "PartitionedAsync",
            "SearchAsync", "TradesAsync", "SummaryAsync", "Available_fundsAsync", "BalancesAsync",
            "MarginsAsync", "Market_valueAsync"
        },

        ["Md"] = new() { "RegsnapshotAsync" },

        ["OAuth"] = new() {
            "Access_tokenAsync", "Live_session_tokenAsync", "Request_tokenAsync", "GenerateTokenAsync"
        },

        ["Pa"] = new() {
            "AllperiodsAsync", "PerformanceAsync", "TransactionsAsync"
        },

        ["Portfolio"] = new() {
            "AccountsAllAsync", "SubaccountsAsync", "AllocationAsync", "LedgerAsync", "MetaAsync",
            "InvalidateAsync", "PositionsAsync", "PositionsAllAsync", "PositionAsync", "Summary2Async"
        },

        ["Sso"] = new() { "ValidateAsync" },

        ["Tickle"] = new() { "TickleAsync" },

        ["Trsrv"] = new() {
            "AllConidsAsync", "FuturesAsync", "SecdefAsync", "ScheduleAsync", "StocksAsync"
        },

        ["Logout"] = new() { "LogoutAsync" },

        ["Ws"] = new() { "WsAsync" }
    };

    public InterfaceSplitter(string sourceInterfacePath, string outputDir)
    {
        _sourceInterfacePath = sourceInterfacePath;
        _outputDir = outputDir;
    }

    public async Task SplitInterfaces()
    {
        Console.WriteLine("=== NSwag Interface Splitter ===\n");
        Console.WriteLine($"Source: {Path.GetFileName(_sourceInterfacePath)}");
        Console.WriteLine($"Output: {_outputDir}\n");

        // Read source interface
        var lines = await File.ReadAllLinesAsync(_sourceInterfacePath);
        var methods = ParseMethods(lines);

        Console.WriteLine($"Parsed {methods.Count} methods from source interface\n");

        // Create output directory
        Directory.CreateDirectory(_outputDir);

        // Generate service interfaces
        foreach (var (serviceName, methodNames) in ServiceMapping)
        {
            var serviceMethods = methods.Where(m => methodNames.Contains(m.Name)).ToList();

            if (serviceMethods.Any())
            {
                await GenerateServiceInterface(serviceName, serviceMethods);
                Console.WriteLine($"  ✓ I{serviceName}Service: {serviceMethods.Count} methods");
            }
            else
            {
                Console.WriteLine($"  ⚠ I{serviceName}Service: No methods found!");
            }
        }

        // Generate composite root interface
        await GenerateRootInterface();
        Console.WriteLine($"\n  ✓ IIBKRClient: Composite root interface");

        Console.WriteLine($"\n✅ Generated {ServiceMapping.Count} service interfaces");
    }

    private List<MethodSignature> ParseMethods(string[] lines)
    {
        var methods = new List<MethodSignature>();
        var currentMethod = new StringBuilder();
        bool inMethod = false;

        foreach (var line in lines)
        {
            var trimmed = line.TrimStart();

            // Skip interface declaration, usings, namespace, braces
            if (trimmed.StartsWith("using ") || trimmed.StartsWith("namespace ") ||
                trimmed.StartsWith("public interface ") || trimmed == "{" || trimmed == "}")
            {
                continue;
            }

            // Start of method (Task< or System.Threading.Tasks.Task)
            if (trimmed.StartsWith("Task<") || trimmed.StartsWith("System.Threading.Tasks.Task "))
            {
                inMethod = true;
                currentMethod.Clear();
                currentMethod.Append(trimmed);
            }
            else if (inMethod)
            {
                currentMethod.Append(" " + trimmed);
            }

            // End of method (semicolon)
            if (inMethod && trimmed.EndsWith(";"))
            {
                var methodStr = currentMethod.ToString();
                var method = ParseMethodSignature(methodStr);
                if (method != null)
                {
                    methods.Add(method);
                }
                inMethod = false;
            }
        }

        return methods;
    }

    private MethodSignature? ParseMethodSignature(string signature)
    {
        // Extract method name (everything before first '(')
        var openParen = signature.IndexOf('(');
        if (openParen == -1) return null;

        var beforeParen = signature.Substring(0, openParen);
        var parts = beforeParen.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return null;

        var methodName = parts[^1]; // Last part is method name

        return new MethodSignature
        {
            Name = methodName,
            FullSignature = signature
        };
    }

    private async Task GenerateServiceInterface(string serviceName, List<MethodSignature> methods)
    {
        var sb = new StringBuilder();

        // Header
        sb.AppendLine("using System;");
        sb.AppendLine("using System.CodeDom.Compiler;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using System.Threading;");
        sb.AppendLine("using System.Threading.Tasks;");
        sb.AppendLine("using IBKR.Api.NSwag.Contract.Models;");
        sb.AppendLine();
        sb.AppendLine("namespace IBKR.Api.V2.Generated.NSwag;");
        sb.AppendLine();
        sb.AppendLine($"/// <summary>");
        sb.AppendLine($"/// {serviceName} service operations");
        sb.AppendLine($"/// </summary>");
        sb.AppendLine("[GeneratedCode(\"NSwag\", \"14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))\")]");
        sb.AppendLine($"public interface I{serviceName}Service");
        sb.AppendLine("{");

        // Methods
        foreach (var method in methods.OrderBy(m => m.Name))
        {
            // Fix ambiguous type references like "Type?" by qualifying them
            var signature = FixAmbiguousTypes(method.FullSignature);
            sb.AppendLine($"\t{signature}");
            sb.AppendLine();
        }

        sb.AppendLine("}");

        // Write file
        var filePath = Path.Combine(_outputDir, $"I{serviceName}Service.cs");
        await File.WriteAllTextAsync(filePath, sb.ToString());
    }

    private string FixAmbiguousTypes(string signature)
    {
        // Use regex to only match "Type" when it's a standalone parameter type, not part of another identifier
        // Match patterns like: "Type?", "Type ", "Type>" but NOT "BarType" or "EnumerationType"
        signature = System.Text.RegularExpressions.Regex.Replace(
            signature,
            @"\b(Type)([\?\s,>])",  // Word boundary + Type + (? or space or comma or >)
            "Models.Type$2"          // Replace with Models.Type + the captured delimiter
        );

        return signature;
    }

    private async Task GenerateRootInterface()
    {
        var sb = new StringBuilder();

        // Header
        sb.AppendLine("using System.CodeDom.Compiler;");
        sb.AppendLine();
        sb.AppendLine("namespace IBKR.Api.V2.Generated.NSwag;");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine("/// Composite root interface providing access to all IBKR API services");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[GeneratedCode(\"NSwag\", \"14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))\")]");
        sb.AppendLine("public interface IIBKRClient");
        sb.AppendLine("{");

        // Service properties
        foreach (var serviceName in ServiceMapping.Keys.OrderBy(s => s))
        {
            sb.AppendLine($"\t/// <summary>{serviceName} service</summary>");
            sb.AppendLine($"\tI{serviceName}Service {serviceName} {{ get; }}");
            sb.AppendLine();
        }

        sb.AppendLine("}");

        // Write file
        var filePath = Path.Combine(_outputDir, "IIBKRClient.cs");
        await File.WriteAllTextAsync(filePath, sb.ToString());
    }

    private class MethodSignature
    {
        public string Name { get; set; } = "";
        public string FullSignature { get; set; } = "";
    }
}
