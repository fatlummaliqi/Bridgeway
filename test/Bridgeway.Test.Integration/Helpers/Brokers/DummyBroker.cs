namespace Bridgeway.Test.Integration.Helpers.Brokers;

[BrokerAlias("DummyBroker")]
public class DummyBroker(IHttpClientFactory httpClientFactory) : Broker(httpClientFactory), IDummyBroker
{
}
