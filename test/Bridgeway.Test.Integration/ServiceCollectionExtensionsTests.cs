using Bridgeway.Test.Integration.Helpers.Brokers;
using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway.Test.Integration;

public class ServiceCollectionExtensionsTests
{
    public const string DummyBrokerAlias = "DummyBroker";

    [Fact]
    public void AddBrokerImplementation_ShouldReturn_ExpectedResult()
    {
        //arrange
        var services = new ServiceCollection();

        //act
        var brokerBuilder = services.AddBroker<DummyBroker>(client => { });

        //assert
        Assert.NotNull(brokerBuilder);
        Assert.NotNull(services.BuildServiceProvider().GetService<DummyBroker>());
        Assert.Equal(DummyBrokerAlias, brokerBuilder.BrokerAlias);
        Assert.Equal(services, brokerBuilder.Services);
    }

    [Fact]
    public void AddBroker_ImplementationWithInterface_ShouldReturn_ExpectedResult()
    {
        //arrange
        var services = new ServiceCollection();

        //act
        var brokerBuilder = services.AddBroker<IDummyBroker, DummyBroker>(client => { });

        //assert
        Assert.NotNull(brokerBuilder);
        Assert.NotNull(services.BuildServiceProvider().GetService<IDummyBroker>());
        Assert.Equal(DummyBrokerAlias, brokerBuilder.BrokerAlias);
        Assert.Equal(services, brokerBuilder.Services);
    }
}
