namespace Bridgeway;

internal static class BaseOptionsExtensions
{
    /// <summary>
    /// Builds an <see cref="HttpRequestMessage"/> based on the provided options, path, HTTP method, and broker alias.
    /// </summary>
    /// <param name="options">
    /// The options to use for building the request. If <c>null</c>, a default request is created.
    /// </param>
    /// <param name="path">
    /// The relative or absolute path for the request URI.
    /// </param>
    /// <param name="method">
    /// The HTTP method to use for the request.
    /// </param>
    /// <param name="brokerAlias">
    /// The alias for the broker, which will be added to the request options.
    /// </param>
    /// <returns>
    /// An <see cref="HttpRequestMessage"/> configured based on the provided parameters.
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// Thrown when the options are not supported for request encoding.
    /// </exception>
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
            IUrlEncoded => HttpRequestUtils.BuildUrlEncodedRequest(path, method, options),
            IJsonEncoded => HttpRequestUtils.BuildJsonEncodedRequest(path, method, options),
            _ => throw new NotSupportedException("Not supported request options encoding.")
        };
    }
}
