using System.Reflection;

namespace Bridgeway.Common;

internal static class CommonHelper
{
    public static string GetBrokerAlias<TBroker>() where TBroker : Broker
    {
        var brokerType = typeof(TBroker);

        if (!brokerType.IsDefined(typeof(BrokerAliasAttribute), inherit: false))
        {
            throw new ArgumentException($"Make sure to mark '{brokerType.Name}' broker with BrokerAliasAttribute.");
        }

        var attribute = brokerType.GetCustomAttribute<BrokerAliasAttribute>();

        return attribute!.Alias;
    }
}
