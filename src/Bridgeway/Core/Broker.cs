using System.Reflection;

namespace Bridgeway;

/// <summary>
/// Serves as an abstract base class for brokers that facilitate HTTP client interactions.
/// Provides methods for sending HTTP requests and processing responses, both synchronously and asynchronously.
/// </summary>
public abstract class Broker(IHttpClientFactory httpClientFactory)
{
    private string Alias
    {
        get
        {
            return GetType().GetCustomAttribute<BrokerAliasAttribute>()!.Alias;
        }
    }

    /// <summary>
    /// Sends a synchronous HTTP request and returns the HTTP response message.
    /// </summary>
    /// <param name="path">The relative path of the HTTP request.</param>
    /// <param name="method">The HTTP method to be used for the request.</param>
    /// <param name="options">Optional request options that will be encoded into request.</param>
    /// <returns>
    /// An <see cref="HttpResponseMessage"/> representing the response from the server.
    /// </returns>
    /// <exception cref="BrokerException">
    /// Thrown when the HTTP response status code indicates a failure.
    /// </exception>
    protected virtual HttpResponseMessage Request(string path, HttpMethod method, BaseOptions? options)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = client.Send(request);

        EnsureSuccessStatusCode(response);

        return response;
    }

    /// <summary>
    /// Sends an asynchronous HTTP request and returns the HTTP response message.
    /// </summary>
    /// <param name="path">The relative path of the HTTP request.</param>
    /// <param name="method">The HTTP method to be used for the request.</param>
    /// <param name="options">Optional request options that will be encoded into request.</param>
    /// <returns>
    /// A <see cref="Task{HttpResponseMessage}"/> representing the asynchronous operation, with the HTTP response message as the result.
    /// </returns>
    /// <exception cref="BrokerException">
    /// Thrown when the HTTP response status code indicates a failure.
    /// </exception>
    protected virtual async Task<HttpResponseMessage> RequestAsync(string path, HttpMethod method, BaseOptions? options, CancellationToken cancellationToken)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = await client.SendAsync(request, cancellationToken);

        EnsureSuccessStatusCode(response);

        return response;
    }

    /// <summary>
    /// Sends a synchronous HTTP request and returns the HTTP response message.
    /// </summary>
    /// <param name="path">The relative path of the HTTP request.</param>
    /// <param name="method">The HTTP method to be used for the request.</param>
    /// <param name="options">Optional request options that will be encoded into request.</param>
    /// <returns>
    /// The result of type <typeparamref name="T"/> extracted from the response payload.
    /// </returns>
    /// <exception cref="BrokerException">
    /// Thrown when the HTTP response status code indicates a failure.
    /// </exception>
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

    /// <summary>
    /// Sends an asynchronous HTTP request and returns the HTTP response message.
    /// </summary>
    /// <param name="path">The relative path of the HTTP request.</param>
    /// <param name="method">The HTTP method to be used for the request.</param>
    /// <param name="options">Optional request options that will be encoded into request.</param>
    /// <returns>
    /// A <see cref="Task{T}"/> representing the asynchronous operation, with the result of type <typeparamref name="T"/> as the result.
    /// </returns>
    /// <exception cref="BrokerException">
    /// Thrown when the HTTP response status code indicates a failure.
    /// </exception>
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
            throw new BrokerException($"Couldn't process response. Server responded with {response.StatusCode} status code.", response);
        }
    }
}
