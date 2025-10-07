# GitHub Workflow Badge

Add this badge to your README.md to show workflow status:

## Badge Markdown

```markdown
[![Build and Release](https://github.com/paulfryer/ibkr/actions/workflows/release.yml/badge.svg)](https://github.com/paulfryer/ibkr/actions/workflows/release.yml)
```

## Badge Preview

[![Build and Release](https://github.com/paulfryer/ibkr/actions/workflows/release.yml/badge.svg)](https://github.com/paulfryer/ibkr/actions/workflows/release.yml)

## Additional Badges

```markdown
<!-- SDK Version -->
![Version](https://img.shields.io/badge/version-1.0.0-blue)

<!-- License -->
![License](https://img.shields.io/badge/license-MIT-green)

<!-- .NET Version -->
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
```

## Example README Section

```markdown
# IBKR API SDK

[![Build and Release](https://github.com/paulfryer/ibkr/actions/workflows/release.yml/badge.svg)](https://github.com/paulfryer/ibkr/actions/workflows/release.yml)
![License](https://img.shields.io/badge/license-MIT-green)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)

Auto-generated C# SDKs for the Interactive Brokers REST API.

## Installation

**NSwag SDK:**
```bash
dotnet add package IBKR.Api.NSwag.Contract
dotnet add package IBKR.Api.NSwag.Client
```

**Kiota SDK:**
```bash
dotnet add package IBKR.Api.Kiota.Contract
dotnet add package IBKR.Api.Kiota.Client
```

## Documentation

See [WORKFLOW-USAGE.md](WORKFLOW-USAGE.md) for release workflow instructions.
```
