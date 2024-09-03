using Bridgeway.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers a broker service and its implementation with the service collection.
    /// </summary>
    /// <typeparam name="TService">
    /// The type of the service to register.
    /// </typeparam>
    /// <typeparam name="TImplementation">
    /// The type of the broker implementation that should be used. It must inherit from <see cref="Broker"/>.
    /// </typeparam>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to which the broker service and implementation will be added.
    /// </param>
    /// <param name="configureClient">
    /// An action to configure the <see cref="HttpClient"/> instance used by the broker.
    /// </param>
    /// <returns>
    /// An <see cref="IBrokerBuilder"/> instance that can be used to further configure the broker.
    /// </returns>
    public static IBrokerBuilder AddBroker<TService, TImplementation>(this IServiceCollection services,
        Action<HttpClient> configureClient) where TImplementation : Broker
    {
        var brokerAlias = CommonHelper.GetBrokerAlias<TImplementation>();

        services.AddHttpClient(brokerAlias, configureClient);
        services.AddScoped(typeof(TService), typeof(TImplementation));

        return new DefaultBrokerBuilder(brokerAlias, services);
    }

    /// <summary>
    /// Registers a broker implementation with the service collection.
    /// </summary>
    /// <typeparam name="TImplementation">
    /// The type of the broker implementation to register. It must inherit from <see cref="Broker"/>.
    /// </typeparam>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to which the broker implementation will be added.
    /// </param>
    /// <param name="configureClient">
    /// An action to configure the <see cref="HttpClient"/> instance used by the broker.
    /// </param>
    /// <returns>
    /// An <see cref="IBrokerBuilder"/> instance that can be used to further configure the broker.
    /// </returns>
    public static IBrokerBuilder AddBroker<TImplementation>(this IServiceCollection services,
        Action<HttpClient> configureClient) where TImplementation : Broker
    {
        var brokerAlias = CommonHelper.GetBrokerAlias<TImplementation>();

        services.AddHttpClient(brokerAlias, configureClient);
        services.AddScoped<TImplementation>();

        return new DefaultBrokerBuilder(brokerAlias, services);
    }
}
