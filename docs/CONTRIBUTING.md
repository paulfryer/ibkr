# Contributing Guide

Thank you for your interest in contributing! This guide explains how to regenerate SDKs, scaffold tests, and contribute to the project.

## Prerequisites

- **.NET 8.0 SDK** or later
- **Git** for version control
- **IDE**: Visual Studio 2022, VS Code, or Rider
- **NSwag CLI** (installed automatically by generator)
- **Kiota CLI** (installed automatically by generator)

## Getting Started

### 1. Fork and Clone

```bash
# Fork the repository on GitHub, then:
git clone https://github.com/YOUR_USERNAME/ibkr.git
cd ibkr
```

### 2. Understand the Structure

```
ibkr/
├── src/
│   ├── IBKR.Api.Generator/      # Regenerate SDKs
│   ├── IBKR.Api.TestScaffold/   # Create test infrastructure
│   ├── Kiota/                   # Generated Kiota SDK
│   └── NSwag/                   # Generated NSwag SDK
│
└── docs/                        # Documentation
```

## Regenerating SDKs

### When to Regenerate

Regenerate SDKs when:
- IBKR updates their OpenAPI specification
- You want to test generator changes
- Adding new endpoints

### Option 1: Generate Both SDKs (Recommended)

```bash
cd src/IBKR.Api.Generator
dotnet run

# When prompted, choose:
# 0 - Generate both NSwag and Kiota SDKs
```

### Option 2: Generate Individual SDK

```bash
cd src/IBKR.Api.Generator
dotnet run

# When prompted, choose:
# 1 - Generate NSwag SDK only
# 2 - Generate Kiota SDK only
```

### What Happens During Generation

1. **Downloads** OpenAPI spec from `https://api.ibkr.com`
2. **Generates** code using NSwag/Kiota CLI tools
3. **Reorganizes** monolithic project into Contract + Client
4. **Builds** projects to verify they compile
5. **Adds** projects to solution file

⏱️ **Time:** ~30-40 seconds for both SDKs

### Verification

```bash
# Build everything
cd src
dotnet build IBKR.Sdk.sln

# Check for errors
# All Contract and Client projects should build successfully
```

## Scaffolding Test Infrastructure

### When to Scaffold

Run the test scaffold when:
- First time setting up the repository
- After deleting MockClient or Test projects
- Creating test infrastructure for first time

⚠️ **Important:** TestScaffold **preserves existing code**. It will NOT overwrite your MockClient or Test projects if they already exist.

### Run Test Scaffold

```bash
cd src/IBKR.Api.TestScaffold
dotnet run
```

### What Gets Created

If projects don't exist:

```
src/
├── Kiota/
│   ├── IBKR.Api.Kiota.MockClient/    # Created
│   └── IBKR.Api.Kiota.Tests/         # Created
│
└── NSwag/
    ├── IBKR.Api.NSwag.MockClient/    # Created
    └── IBKR.Api.NSwag.Tests/         # Created
```

If projects already exist:
```
✓ IBKR.Api.NSwag.MockClient already exists - preserving user code
✓ IBKR.Api.Kiota.MockClient already exists - preserving user code
```

## Implementing Mocks

### NSwag MockClient

Edit `src/NSwag/IBKR.Api.NSwag.MockClient/Services/MockFyiService.cs`:

```csharp
public class MockFyiService : IFyiService
{
    public Task<Response> UnreadnumberAsync(CancellationToken cancellationToken = default)
    {
        // Replace NotImplementedException with actual mock data
        return Task.FromResult(new Response
        {
            UnreadCount = 5,
            Timestamp = DateTimeOffset.UtcNow
        });
    }

    // Implement other methods as needed for your tests
}
```

### Kiota MockClient

Edit `src/Kiota/IBKR.Api.Kiota.MockClient/MockRequestAdapter.cs`:

```csharp
// In test setup or mock constructor
public void ConfigureMockResponses()
{
    SetCannedResponse("/fyi/unreadnumber", new Response
    {
        UnreadCount = 5
    });

    SetCannedResponse("/fyi/notifications", new List<NotificationMessage>
    {
        new() { Id = "1", Message = "Test notification" }
    });
}
```

## Writing Tests

### Example Test

```csharp
// src/NSwag/IBKR.Api.NSwag.Tests/FyiServiceTests.cs
[Fact]
public async Task UnreadNumber_ReturnsExpectedCount()
{
    // Arrange
    // (TestFixture handles DI and config)

    // Act
    var response = await _fyiService.UnreadnumberAsync();

    // Assert
    Assert.NotNull(response);
    Assert.Equal(5, response.UnreadCount);
}
```

### Running Tests

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test src/NSwag/IBKR.Api.NSwag.Tests/

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"
```

## Making Changes

### Before Making Changes

1. Create a new branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. Ensure everything builds:
   ```bash
   dotnet build
   ```

### Types of Contributions

#### 1. Documentation Improvements

Edit files in `/docs`:
- Fix typos
- Add examples
- Clarify explanations
- Add troubleshooting tips

#### 2. Generator Enhancements

Edit `src/IBKR.Api.Generator/`:
- Improve reorganization logic
- Add new transformations
- Fix generation bugs

**Test your changes:**
```bash
# Delete generated SDKs
rm -rf src/Kiota src/NSwag

# Regenerate with your changes
cd src/IBKR.Api.Generator
dotnet run

# Verify build
cd ../
dotnet build IBKR.Sdk.sln
```

#### 3. Test Infrastructure Improvements

Edit `src/IBKR.Api.TestScaffold/`:
- Improve mock templates
- Enhance test fixtures
- Add configuration options

**Test your changes:**
```bash
# Delete test projects
rm -rf src/Kiota/*MockClient src/Kiota/*Tests
rm -rf src/NSwag/*MockClient src/NSwag/*Tests

# Regenerate with your changes
cd src/IBKR.Api.TestScaffold
dotnet run

# Verify build
cd ../
dotnet build IBKR.Sdk.sln
dotnet test
```

#### 4. Workflow Improvements

Edit `.github/workflows/release.yml`:
- Add validation steps
- Improve artifact handling
- Enhance summaries

**Test locally:**
```bash
# Install act (https://github.com/nektos/act)
act -W .github/workflows/release.yml -n
```

### Commit Guidelines

Use conventional commit messages:

```
feat: Add retry logic to generator
fix: Resolve namespace collision in NSwag reorganizer
docs: Update getting started guide with troubleshooting
test: Add integration tests for Kiota client
chore: Update dependency versions
```

## Pull Request Process

### 1. Prepare Your PR

```bash
# Ensure everything builds
dotnet build

# Run tests
dotnet test

# Commit your changes
git add .
git commit -m "feat: Your feature description"

# Push to your fork
git push origin feature/your-feature-name
```

### 2. Create Pull Request

1. Go to https://github.com/paulfryer/ibkr
2. Click "New Pull Request"
3. Select your fork and branch
4. Fill in the PR template:

```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Breaking change

## Testing
- [ ] Regenerated SDKs successfully
- [ ] All tests pass
- [ ] Added new tests (if applicable)

## Checklist
- [ ] Code follows project style
- [ ] Documentation updated
- [ ] No breaking changes (or documented)
```

### 3. PR Review

- Maintainers will review your PR
- Address any feedback
- Once approved, maintainers will merge

## Code Style Guidelines

### C# Conventions

Follow standard C# conventions:
- Use PascalCase for public members
- Use camelCase for private fields
- Use async/await for async code
- Add XML documentation for public APIs

```csharp
/// <summary>
/// Reorganizes the generated SDK into Contract and Client projects.
/// </summary>
/// <param name="sourceDir">Directory containing generated code</param>
public void Reorganize(string sourceDir)
{
    // Implementation
}
```

### Documentation Style

- Use clear, concise language
- Include code examples
- Add troubleshooting sections
- Use emoji sparingly for visual hierarchy (✅ ❌ ⚠️)

## Testing Your Changes

### Full Workflow Test

```bash
# 1. Clean slate
rm -rf src/Kiota src/NSwag

# 2. Generate SDKs
cd src/IBKR.Api.Generator
dotnet run    # Choose option 0

# 3. Scaffold tests
cd ../IBKR.Api.TestScaffold
dotnet run

# 4. Build everything
cd ../
dotnet build IBKR.Sdk.sln

# 5. Run tests
dotnet test

# Success: All steps complete without errors
```

### Incremental Testing

```bash
# Test only your changes
dotnet build src/IBKR.Api.Generator/
dotnet run --project src/IBKR.Api.Generator/
```

## Troubleshooting

### "kiota: command not found"

The generator automatically installs Kiota. If manual install needed:

```bash
dotnet tool install --global Microsoft.OpenApi.Kiota
```

### "nswag: command not found"

The generator automatically installs NSwag. If manual install needed:

```bash
dotnet tool install --global NSwag.ConsoleCore
```

### Build Errors After Generation

1. Clean solution:
   ```bash
   dotnet clean
   ```

2. Restore packages:
   ```bash
   dotnet restore
   ```

3. Rebuild:
   ```bash
   dotnet build
   ```

### Tests Failing

1. Check mock implementations are complete
2. Verify appsettings.json files exist
3. Ensure `UseMockClient: true` in test config

## Project Maintenance

### Updating OpenAPI Spec

The generator downloads the latest spec automatically. To use a specific version:

```csharp
// Edit Program.cs
var specUrl = "https://api.ibkr.com/v1/openapi/openapi.json?version=1.2.3";
```

### Updating Dependencies

```bash
# Update all packages
dotnet outdated
dotnet outdated --upgrade
```

### Updating Generator Tools

```bash
# Update Kiota
dotnet tool update --global Microsoft.OpenApi.Kiota

# Update NSwag
dotnet tool update --global NSwag.ConsoleCore
```

## Community

- **Issues**: https://github.com/paulfryer/ibkr/issues
- **Discussions**: https://github.com/paulfryer/ibkr/discussions

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

**Questions?** Open an issue or discussion on GitHub!
