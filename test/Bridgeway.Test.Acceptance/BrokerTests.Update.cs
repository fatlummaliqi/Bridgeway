using Bridgeway.Test.Acceptance.Brokers.Options;

namespace Bridgeway.Test.Acceptance;

public partial class BrokerTests
{
    [Fact]
    public async Task UpdateAsync_ShouldReturn_ExpectedResult()
    {
        //arrange
        var todoId = 1;
        var options = new UpsertTodoOptions
        {
            Title = "Hello World",
            Completed = true,
            UserId = 321
        };

        //act
        var todo = await Broker.UpdateAsync(todoId, options);

        //assert
        Assert.NotNull(todo);
        Assert.Equal(options.Title, todo.Title);
        Assert.Equal(options.Completed, todo.Completed);
        Assert.Equal(options.UserId, todo.UserId);
        Assert.Equal(todoId, todo.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrow_BrokerException()
    {
        //arrange 
        var todoId = 0;
        var options = new UpsertTodoOptions
        {
            Title = "Hello World",
            Completed = true,
            UserId = 321
        };

        //act
        var action = () => Broker.UpdateAsync(todoId, options);

        //assert
        await Assert.ThrowsAsync<BrokerException>(action);
    }
}
