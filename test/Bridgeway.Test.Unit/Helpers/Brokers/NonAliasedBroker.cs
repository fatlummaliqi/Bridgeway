namespace Bridgeway.Test.Unit.Helpers.Brokers;

internal class NonAliasedBroker : Broker
{
    public NonAliasedBroker() : base(httpClientFactory: null!)
    {
    }
}
