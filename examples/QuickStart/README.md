# IBKR SDK Quick Start Example

This example demonstrates the AWS SDK-like developer experience of the IBKR SDK.

## Setup

1. **Configure your IBKR credentials** in `appsettings.json`:

```json
{
  "IBKR": {
    "ClientId": "YOUR_CLIENT_ID",
    "Credential": "YOUR_USERNAME",
    "ClientKeyId": "YOUR_KEY_ID_FROM_PORTAL",
    "ClientPemPath": "/path/to/your/private-key.pem",
    "BaseUrl": "https://api.ibkr.com"
  }
}
```

2. **Run the example**:

```bash
dotnet run
```

## What This Demonstrates

- **One-line setup**: `services.AddIBKRSdk(configuration.GetSection("IBKR"))`
- **Configuration-based**: No hardcoded credentials in code
- **Environment variable support**: Override appsettings.json with env vars
- **Dependency injection**: Clean, testable architecture
- **Strongly-typed results**: DateTime, enums, decimals instead of strings

## Expected Output

```
IBKR SDK Quick Start
====================

Fetching option chain for AAPL...

Symbol: AAPL
Underlying Contract ID: 265598
Total Contracts Retrieved: 156
Retrieved At: 2025-10-08 17:30:00 UTC

First 10 Contracts:
-------------------
AAPL   Call Strike:   $90.00 Exp: 2025-10-17 (  9 days) Exchange: SMART
AAPL   Call Strike:   $95.00 Exp: 2025-10-17 (  9 days) Exchange: SMART
AAPL   Put  Strike:   $90.00 Exp: 2025-10-17 (  9 days) Exchange: SMART
...

Contracts by Expiration:
------------------------
2025-10-17:  52 contracts (26 calls, 26 puts)
2025-10-24:  48 contracts (24 calls, 24 puts)
2025-10-31:  56 contracts (28 calls, 28 puts)
```

## Environment Variables

You can override any setting using environment variables:

```bash
export IBKR_CLIENT_ID="YOUR_CLIENT_ID"
export IBKR_CREDENTIAL="YOUR_USERNAME"
export IBKR_CLIENT_KEY_ID="YOUR_KEY_ID"
export IBKR_CLIENT_PEM_PATH="/path/to/key.pem"
dotnet run
```

## Learn More

- [IBKR SDK Guide](../../docs/IBKR-SDK.md)
- [Getting Started Guide](../../docs/GETTING-STARTED.md)
- [SDK Comparison](../../docs/SDK-COMPARISON.md)
