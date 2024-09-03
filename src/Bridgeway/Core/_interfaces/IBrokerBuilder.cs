using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway;

/// <summary>
/// Defines a contract for building and configuring a broker.
/// </summary>
public interface IBrokerBuilder
{
    /// <summary>
    /// Gets the alias for the broker.
    /// </summary>
    string BrokerAlias { get; }

    /// <summary>
    /// Gets the collection of services.
    /// </summary>
    IServiceCollection Services { get; }
}
