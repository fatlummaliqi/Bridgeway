using System.Collections;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace Bridgeway;

internal static class HttpRequestUtils
{
    public static HttpRequestMessage BuildUrlEncoedRequest(string path, HttpMethod method, BaseOptions options)
    {
        var stringBuilder = new StringBuilder("?");

        foreach (var prop in options.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (!prop.CanRead) continue;

            if (prop.IsDefined(typeof(JsonIgnoreAttribute))) continue;

            var value = prop.GetValue(options);

            if (value == null) continue;

            var parameterKey = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;

            if (value is not string && value is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    stringBuilder.AppendFormat("{0}={1}&", parameterKey, HttpUtility.UrlEncode(item.ToString()));
                }

                continue;
            }

            stringBuilder.AppendFormat("{0}={1}&", parameterKey, HttpUtility.UrlEncode(value.ToString()));
        }

        return new HttpRequestMessage
        {
            RequestUri = new Uri(path + stringBuilder.ToString(), UriKind.Relative),
            Method = method
        };
    }

    public static HttpRequestMessage BuildJsonEncodedRequest(string path, HttpMethod method, BaseOptions options)
    {
        var @params = new Dictionary<string, object>();

        foreach (var prop in options.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (!prop.CanRead) continue;

            var value = prop.GetValue(options);

            if (value == null) continue;

            var parameterKey = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;

            @params.Add(parameterKey, value);
        }

        var payload = JsonSerializer.Serialize(@params);

        return new HttpRequestMessage
        {
            RequestUri = new Uri(path, UriKind.Relative),
            Method = method,
            Content = new StringContent(payload, Encoding.UTF8, MediaTypeNames.Application.Json)
        };
    }
}
