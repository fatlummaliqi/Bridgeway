using System.Reflection;

namespace Bridgeway;

public abstract class Broker(IHttpClientFactory httpClientFactory)
{
    private string Alias
    {
        get
        {
            return GetType().GetCustomAttribute<BrokerAliasAttribute>()!.Alias;
        }
    }

    protected virtual HttpResponseMessage Request(string path, HttpMethod method, BaseOptions? options)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = client.Send(request);

        EnsureSuccessStatusCode(response);

        return response;
    }

    protected virtual async Task<HttpResponseMessage> RequestAsync(string path, HttpMethod method, BaseOptions? options, CancellationToken cancellationToken)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = await client.SendAsync(request, cancellationToken);

        EnsureSuccessStatusCode(response);

        return response;
    }

    protected virtual T Request<T>(string path, HttpMethod method, BaseOptions? options)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = client.Send(request);

        EnsureSuccessStatusCode(response);

        return (T)HttpContentUtils.ProcessPayloadAsync(response.Content, typeof(T))
            .GetAwaiter()
            .GetResult();
    }

    protected virtual async Task<T> RequestAsync<T>(string path, HttpMethod method, BaseOptions options, CancellationToken cancellationToken)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = await client.SendAsync(request, cancellationToken);

        EnsureSuccessStatusCode(response);

        return (T)await HttpContentUtils.ProcessPayloadAsync(response.Content, typeof(T), cancellationToken);
    }

    private static void EnsureSuccessStatusCode(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new BrokerException($"Couldn't process response. Server responded with {response.StatusCode} status code.");
        }
    }
}
