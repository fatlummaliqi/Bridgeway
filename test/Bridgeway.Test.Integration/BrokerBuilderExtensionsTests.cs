using Bridgeway.Test.Integration.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway.Test.Integration;

public class BrokerBuilderExtensionsTests
{
    public const string DummyBrokerAlias = "DummyBroker";

    [Fact]
    public void AddAuthorizationStrategy_ShouldReturn_ExpectedResult()
    {
        //arrange
        var services = new ServiceCollection();
        var brokerBuilder = new DefaultBrokerBuilder(DummyBrokerAlias, services) as IBrokerBuilder;

        //act 
        brokerBuilder = brokerBuilder.AddAuthorizationStrategy<DummyAuthorizationStrategy>();

        //assert
        Assert.NotNull(brokerBuilder);
        Assert.NotNull(services.BuildServiceProvider().GetKeyedService<IAuthorizationStrategy>(DummyBrokerAlias));
    }
}
