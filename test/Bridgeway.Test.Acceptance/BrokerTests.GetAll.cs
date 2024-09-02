using Bridgeway.Test.Acceptance.Brokers.Options;

namespace Bridgeway.Test.Acceptance;

public partial class BrokerTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturn_ExpectedResult()
    {
        //arrange
        var options = new GetTodoOptions();

        //act
        var todos = await Broker.GetAllAsync(options);

        //assert
        Assert.NotNull(todos);
        Assert.NotEmpty(todos);
    }
}
