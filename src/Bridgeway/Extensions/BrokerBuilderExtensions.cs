using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

public static class BrokerBuilderExtensions
{
    public static IBrokerBuilder AddAuthorizationStrategy<TImplementation>(this IBrokerBuilder builder)
        where TImplementation : IAuthorizationStrategy
    {
        var services = builder.Services;
        var brokerAlias = builder.BrokerAlias;

        services.AddKeyedScoped(typeof(IAuthorizationStrategy), brokerAlias, typeof(TImplementation));

        return builder;
    }
}
