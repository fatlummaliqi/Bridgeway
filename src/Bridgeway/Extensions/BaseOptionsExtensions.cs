namespace Bridgeway;

internal static class BaseOptionsExtensions
{
    public static HttpRequestMessage BuildRequest(this BaseOptions? options, string path, HttpMethod method, string brokerAlias)
    {
        if (options == null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(path, UriKind.Relative),
                Method = method,
            };

            request.Options.TryAdd(BridgewayDefaults.BrokerRequestOptionKey, brokerAlias);

            return request;
        }

        return options switch
        {
            IUrlEncoded => HttpRequestUtils.BuildUrlEncoedRequest(path, method, options),
            IJsonEncoded => HttpRequestUtils.BuildJsonEncodedRequest(path, method, options),
            _ => throw new NotSupportedException("Not supported request options encoding.")
        };
    }
}
