﻿using System.Reflection;

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

        return response;
    }

    protected virtual async Task<HttpResponseMessage> RequestAsync(string path, HttpMethod method, BaseOptions? options, CancellationToken cancellationToken)
    {
        var request = options.BuildRequest(path, method, Alias);

        var client = httpClientFactory.CreateClient(Alias);

        var response = await client.SendAsync(request, cancellationToken);

        return response;
    }
}
