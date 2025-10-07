using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using IBKR.Api.Client.Exceptions;

namespace IBKR.Api.Client.Http.Infrastructure;

/// <summary>
/// Core HTTP client wrapper for IBKR API.
/// Handles HTTP requests, JSON serialization, and error mapping.
/// </summary>
public class IBKRHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public IBKRHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        // Configure JSON serialization options to match IBKR API
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
    }

    /// <summary>
    /// Sends a GET request and deserializes the response.
    /// </summary>
    public async Task<TResponse> GetAsync<TResponse>(
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a POST request with JSON body and deserializes the response.
    /// </summary>
    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string requestUri,
        TRequest content,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(requestUri, content, _jsonOptions, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a POST request without body and deserializes the response.
    /// </summary>
    public async Task<TResponse> PostAsync<TResponse>(
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync(requestUri, null, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a PUT request with JSON body and deserializes the response.
    /// </summary>
    public async Task<TResponse> PutAsync<TRequest, TResponse>(
        string requestUri,
        TRequest content,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync(requestUri, content, _jsonOptions, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Sends a DELETE request and deserializes the response.
    /// </summary>
    public async Task<TResponse> DeleteAsync<TResponse>(
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync(requestUri, cancellationToken);
        return await HandleResponseAsync<TResponse>(response, cancellationToken);
    }

    /// <summary>
    /// Handles HTTP response, checks for errors, and deserializes content.
    /// </summary>
    private async Task<TResponse> HandleResponseAsync<TResponse>(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        // Handle error status codes
        if (!response.IsSuccessStatusCode)
        {
            await ThrowAppropriateExceptionAsync(response, cancellationToken);
        }

        // Deserialize successful response
        try
        {
            var content = await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions, cancellationToken);
            return content ?? throw new IBKRApiException(
                "Response content was null",
                response.StatusCode,
                await response.Content.ReadAsStringAsync(cancellationToken));
        }
        catch (JsonException ex)
        {
            throw new IBKRApiException(
                $"Failed to deserialize response: {ex.Message}",
                response.StatusCode,
                await response.Content.ReadAsStringAsync(cancellationToken),
                ex);
        }
    }

    /// <summary>
    /// Throws the appropriate custom exception based on HTTP status code.
    /// </summary>
    private static async Task ThrowAppropriateExceptionAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var statusCode = response.StatusCode;

        switch (statusCode)
        {
            case HttpStatusCode.Unauthorized:
                throw new AuthenticationException(
                    "Authentication failed. Check your credentials.",
                    content);

            case HttpStatusCode.TooManyRequests:
                var retryAfter = response.Headers.RetryAfter?.Date;
                throw new RateLimitExceededException(
                    "Rate limit exceeded",
                    content,
                    retryAfter);

            case HttpStatusCode.Forbidden:
                // Could be session expired
                throw new SessionExpiredException(
                    "Session expired or access forbidden",
                    content,
                    DateTimeOffset.UtcNow);

            default:
                throw new IBKRApiException(
                    $"HTTP request failed with status code {(int)statusCode} ({statusCode})",
                    statusCode,
                    content);
        }
    }
}
