using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

public static class BrokerBuilderExtensions
{
    /// <summary>
    /// Adds an authorization strategy implementation for the <see cref="IBrokerBuilder"/> broker.
    /// </summary>
    /// <typeparam name="TImplementation">
    /// The type of the authorization strategy implementation to add. It must implement <see cref="IAuthorizationStrategy"/>.
    /// </typeparam>
    /// <param name="builder">
    /// The <see cref="IBrokerBuilder"/> instance to which the authorization strategy will be added.
    /// </param>
    /// <returns>
    /// The <see cref="IBrokerBuilder"/> instance with the added authorization strategy.
    /// </returns>
    public static IBrokerBuilder AddAuthorizationStrategy<TImplementation>(this IBrokerBuilder builder)
        where TImplementation : IAuthorizationStrategy
    {
        var services = builder.Services;
        var brokerAlias = builder.BrokerAlias;

        services.AddKeyedScoped(typeof(IAuthorizationStrategy), brokerAlias, typeof(TImplementation));

        return builder;
    }
}
