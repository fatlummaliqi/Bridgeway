using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

internal class AuthorizationHandler(IServiceProvider serviceProvider) : DelegatingHandler
{
    private static readonly HttpRequestOptionsKey<string> RequestOptionsKey = new(BridgewayDefaults.BrokerRequestOptionKey);

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Options.TryGetValue(RequestOptionsKey, out var brokerAlias))
        {
            var authorizationStrategy = serviceProvider.GetKeyedService<IAuthorizationStrategy>(brokerAlias);

            if (authorizationStrategy != null)
            {
                authorizationStrategy
                    .AuthorizeAsync(request, cancellationToken)
                    .GetAwaiter()
                    .GetResult();
            }
        }

        return base.Send(request, cancellationToken);
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Options.TryGetValue(RequestOptionsKey, out var brokerAlias))
        {
            var authorizationStrategy = serviceProvider.GetKeyedService<IAuthorizationStrategy>(brokerAlias);

            if (authorizationStrategy != null)
            {
                await authorizationStrategy.AuthorizeAsync(request, cancellationToken);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
