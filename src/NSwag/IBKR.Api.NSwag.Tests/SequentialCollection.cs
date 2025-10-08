using Xunit;

namespace IBKR.Api.NSwag.Tests;

/// <summary>
/// Collection definition for tests that must run sequentially to avoid IBKR API rate limiting.
///
/// Tests that hit the real IBKR API should use this collection to prevent:
/// - Multiple simultaneous session initializations
/// - Rate limit violations (401 errors)
/// - Resource contention
///
/// Usage: Add [Collection("IBKR API Sequential")] to test classes.
/// </summary>
[CollectionDefinition("IBKR API Sequential", DisableParallelization = true)]
public class SequentialCollection
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
