using System.Net.Mime;
using System.Text.Json;

namespace Bridgeway;

internal static class HttpContentUtils
{
    public static async Task<object> ProcessPayloadAsync(HttpContent content, Type destinationType, CancellationToken cancellationToken = default)
    {
        var contentType = content!.Headers!.ContentType!.MediaType;

        return contentType switch
        {
            MediaTypeNames.Application.Json => await ParseJsonAsync(content, destinationType, cancellationToken),
            _ => throw new NotSupportedException("Not supported response payload content type.")
        };
    }

    private static async Task<object> ParseJsonAsync(HttpContent content, Type destinationType, CancellationToken cancellationToken)
    {
        var payload = await content.ReadAsStringAsync(cancellationToken);

        try
        {
            return JsonSerializer.Deserialize(payload, destinationType)!;
        }
        catch (Exception ex)
        {
            throw new BrokerException("Failed processing json encoded response payload.", ex);
        }
    }
}
