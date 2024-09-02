namespace Bridgeway.Test.Acceptance;

public partial class BrokerTests
{
    [Fact]
    public async Task GetByIdAsync_ShouldReturn_ExpectedResult()
    {
        //arrange
        var todoId = 1;

        //act
        var todo = await Broker.GetByIdAsync(todoId);

        //assert
        Assert.NotNull(todo);
        Assert.Equal(todoId, todo.Id);
    }
}
