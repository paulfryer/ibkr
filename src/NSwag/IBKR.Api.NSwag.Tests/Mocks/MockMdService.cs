using IBKR.Api.NSwag.Contract.Interfaces;
using IBKR.Api.NSwag.Contract.Models;
using Task = System.Threading.Tasks.Task;

namespace IBKR.Api.NSwag.MockClient.Services;

/// <summary>
/// Mock implementation of IMdService for testing.
/// Returns canned responses without making actual API calls.
/// </summary>
public class MockMdService : IMdService
{
    public System.Threading.Tasks.Task<RegsnapshotData> RegsnapshotAsync(string conid, CancellationToken cancellationToken = default)
    {
        // Return mock regulatory snapshot
        var snapshot = new RegsnapshotData
        {
            Conid = int.Parse(conid),
            ConidEx = conid,
            _84 = "150.20",  // Bid
            _86 = "150.30",  // Ask
            _88 = 200,       // Bid Size
            _85 = 100        // Ask Size
        };

        return System.Threading.Tasks.Task.FromResult(snapshot);
    }
}
