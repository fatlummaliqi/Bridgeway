using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

public  interface IBrokerBuilder
{
    string BrokerAlias { get; }

    IServiceCollection Services { get; }
}
