namespace IBKR.Api.NSwag.Authentication;

/// <summary>
/// HTTP message handler that logs all request and response details for debugging
/// </summary>
public class LoggingHttpHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Console.WriteLine("=== HTTP REQUEST ===");
        Console.WriteLine($"Method: {request.Method}");
        Console.WriteLine($"URI: {request.RequestUri}");
        Console.WriteLine("Headers:");
        foreach (var header in request.Headers)
        {
            Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
        }

        if (request.Content != null)
        {
            Console.WriteLine("Content Headers:");
            foreach (var header in request.Content.Headers)
            {
                Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
            }

            var content = await request.Content.ReadAsStringAsync(cancellationToken);
            if (!string.IsNullOrEmpty(content))
            {
                Console.WriteLine($"Body: {content}");
            }
        }

        var response = await base.SendAsync(request, cancellationToken);

        Console.WriteLine("=== HTTP RESPONSE ===");
        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
        Console.WriteLine("Headers:");
        foreach (var header in response.Headers)
        {
            Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
        }

        if (response.Content != null)
        {
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine($"Body: {responseContent}");
        }

        Console.WriteLine("===================");

        return response;
    }
}
