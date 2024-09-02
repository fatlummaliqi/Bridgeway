using Bridgeway.Common;
using Bridgeway.Test.Unit.Helpers.Brokers;

namespace Bridgeway.Test.Unit;

public class CommonHelperTests
{
    [Fact]
    public void GetBrokerAlias_ShouldThrow_ArgumentException()
    {
        //act
        Action action = () => CommonHelper.GetBrokerAlias<NonAliasedBroker>();

        //assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void GetBrokerAlias_ShouldReturn_ExpectedValue()
    {
        //arrange
        const string ExpectedBrokerAlias = "AliasedBroker";

        //act
        var alias = CommonHelper.GetBrokerAlias<AliasedBroker>();

        //assert
        Assert.NotNull(alias);
        Assert.NotEmpty(alias);
        Assert.Equal(ExpectedBrokerAlias, alias);
    }
}
