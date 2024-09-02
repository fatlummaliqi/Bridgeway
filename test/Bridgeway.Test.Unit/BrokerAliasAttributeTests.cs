namespace Bridgeway.Test.Unit;

public class BrokerAliasAttributeTests
{
    [Fact]
    public void Constructor_ShoudlThrow_ArgumentException_OnNullAlias()
    {
        //arrange 
        string alias = null!;

        //act
        Action action = () => new BrokerAliasAttribute(alias);

        //assert
        Assert.Throws<ArgumentException>(action);   
    }

    [Fact]
    public void Constructor_ShoudlThrow_ArgumentException_OnEmptyAlias()
    {
        //arrange 
        string alias = string.Empty;

        //act
        Action action = () => new BrokerAliasAttribute(alias);

        //assert
        Assert.Throws<ArgumentException>(action);
    }
}
