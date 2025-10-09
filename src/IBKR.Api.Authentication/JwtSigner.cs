using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace IBKR.Api.Authentication;

/// <summary>
/// JWT signing with RSA for IBKR OAuth2
/// </summary>
internal class JwtSigner
{
    private readonly string _pemPath;
    private readonly string _clientKeyId;

    public JwtSigner(string pemPath, string clientKeyId)
    {
        _pemPath = pemPath;
        _clientKeyId = clientKeyId;
    }

    /// <summary>
    /// Create client assertion JWT for OAuth2 token request
    /// </summary>
    public string CreateClientAssertion(string clientId)
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var header = new Dictionary<string, object>
        {
            { "typ", "JWT" },
            { "alg", "RS256" },
            { "kid", _clientKeyId }
        };

        var claims = new Dictionary<string, object>
        {
            { "sub", clientId },
            { "aud", "/token" },
            { "iss", clientId },
            { "exp", now + 20 },
            { "iat", now - 10 }
        };

        return MakeJws(header, claims);
    }

    /// <summary>
    /// Create signed request JWT for SSO session (bearer token)
    /// </summary>
    public string CreateSignedRequest(string clientId, string credential, string ipAddress)
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var header = new Dictionary<string, object>
        {
            { "typ", "JWT" },
            { "alg", "RS256" },
            { "kid", _clientKeyId }
        };

        var claims = new Dictionary<string, object>
        {
            { "ip", ipAddress },
            { "service", "AM.LOGIN" },
            { "credential", credential },
            { "iss", clientId },
            { "exp", now + 86400 },
            { "iat", now }
        };

        return MakeJws(header, claims);
    }

    /// <summary>
    /// Create and sign JWT (JWS - JSON Web Signature)
    /// </summary>
    private string MakeJws(Dictionary<string, object> header, Dictionary<string, object> claims)
    {
        // Encode header
        var jsonHeader = JsonConvert.SerializeObject(header);
        var b64Header = Base64UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonHeader)));

        // Encode claims
        var jsonClaims = JsonConvert.SerializeObject(claims);
        var b64Claims = Base64UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonClaims)));

        // Create payload to sign
        var payload = $"{b64Header}.{b64Claims}";

        // Sign with RSA
        var signature = SignPayload(payload);
        var encodedSignature = Base64UrlEncode(Convert.ToBase64String(signature));

        return $"{payload}.{encodedSignature}";
    }

    /// <summary>
    /// Sign payload using RSA with PKCS#1 padding and SHA256
    /// </summary>
    private byte[] SignPayload(string payload)
    {
        // Hash the payload with SHA256
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(payload));

        // Load RSA key from PEM file
        using var rsa = RSA.Create();
        rsa.KeySize = 3072;
        var pemContent = File.ReadAllText(_pemPath);
        rsa.ImportFromPem(pemContent);

        // Sign the hash using PKCS#1 padding
        var signature = rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        return signature;
    }

    /// <summary>
    /// Base64 URL encoding (replace +/= with -_)
    /// </summary>
    private static string Base64UrlEncode(string base64)
    {
        return base64
            .Replace('+', '-')
            .Replace('/', '_')
            .Replace("=", "");
    }
}
