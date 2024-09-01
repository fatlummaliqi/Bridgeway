namespace Bridgeway.Test.Unit.Helpers.Brokers;

[BrokerAlias("AliasedBroker")]
internal class AliasedBroker : Broker
{
    public AliasedBroker() : base(httpClientFactory: null!)
    {
    }
}
