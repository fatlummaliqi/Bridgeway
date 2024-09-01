using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

internal class DefaultBrokerBuilder(string brokerAlias, IServiceCollection services) : IBrokerBuilder
{
    public string BrokerAlias { get; } = brokerAlias;

    public IServiceCollection Services { get; } = services;
}

