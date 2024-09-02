namespace Bridgeway.Test.Acceptance;

public partial class BrokerTests
{
    [Fact]
    public async Task DeleteTodoAsync_ShouldReturn_True()
    {
        //arrange
        var todoId = 123;

        //act
        var deleted = await Broker.DeleteTodoAsync(todoId);

        //assert
        Assert.True(deleted);
    }
}
