using Bridgeway.Test.Acceptance.Brokers;
using Microsoft.Extensions.DependencyInjection;

namespace Bridgeway.Test.Acceptance;

public partial class BrokerTests
{
    private static IServiceProvider _serviceProvider;

    static BrokerTests()
    {
        var services = new ServiceCollection();

        services
            .AddBroker<IJsonPlaceholderBroker, JsonPlaceholderBroker>(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            })
            .AddAuthorizationStrategy<JsonPlaceholderApiAuthorizationStrategy>();

        _serviceProvider = services.BuildServiceProvider();
    }

    private IJsonPlaceholderBroker Broker
    {
        get
        {
            return _serviceProvider.GetRequiredService<IJsonPlaceholderBroker>();
        }
    }
}
