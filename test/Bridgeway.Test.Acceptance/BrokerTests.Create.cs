using Bridgeway.Test.Acceptance.Brokers.Options;

namespace Bridgeway.Test.Acceptance;

public partial class BrokerTests
{
    [Fact]
    public async Task CreateTodoAsync_ShouldReturn_ExceptedResult()
    {
        //arrange
        var options = new UpsertTodoOptions
        {
            Title = "Hello world",
            Completed = false,
            UserId = 123
        };

        //act
        var todo = await Broker.CreateTodoAsync(options);

        //assert
        Assert.NotNull(todo);
        Assert.Equal(options.Title, todo.Title);
        Assert.Equal(options.Completed, todo.Completed);
        Assert.Equal(options.UserId, todo.UserId);
        Assert.True(todo.Id > 0);
    }
}
