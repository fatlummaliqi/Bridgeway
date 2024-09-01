namespace Bridgeway.Test.Unit.Brokers;

internal class NonAliasedBroker : Broker
{
    public NonAliasedBroker() : base(httpClientFactory: null!)
    {
    }
}
