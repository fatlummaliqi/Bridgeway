using Bridgeway.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bridgeway;

public static class ServiceCollectionExtensions
{
    public static IBrokerBuilder AddBroker<TService, TImplementation>(this IServiceCollection services,
        Action<HttpClient> configureClient) where TImplementation : Broker
    {
        var brokerAlias = CommonHelper.GetBrokerAlias<TImplementation>();

        services.AddHttpClient(brokerAlias, configureClient);
        services.AddScoped(typeof(TService), typeof(TImplementation));

        return new DefaultBrokerBuilder(brokerAlias, services);
    }

    public static IBrokerBuilder AddBroker<TImplementation>(this IServiceCollection services,
        Action<HttpClient> configureClient) where TImplementation : Broker
    {
        var brokerAlias = CommonHelper.GetBrokerAlias<TImplementation>();

        services.AddHttpClient(brokerAlias, configureClient);
        services.AddScoped<TImplementation>();

        return new DefaultBrokerBuilder(brokerAlias, services);
    }
}
