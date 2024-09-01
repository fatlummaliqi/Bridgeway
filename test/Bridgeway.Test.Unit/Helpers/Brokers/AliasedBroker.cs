namespace Bridgeway.Test.Unit.Brokers;

[BrokerAlias("AliasedBroker")]
internal class AliasedBroker : Broker
{
    public AliasedBroker() : base(httpClientFactory: null!)
    {
    }
}
