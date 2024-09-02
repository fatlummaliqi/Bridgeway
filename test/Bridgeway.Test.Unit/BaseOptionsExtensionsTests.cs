using Bridgeway.Test.Unit.Helpers.Options;

namespace Bridgeway.Test.Unit;

public class BaseOptionsExtensionsTests
{
    public const string UrlPath = "/api/v1/dummy-resource-path";
    public const string BrokerAlias = "broker-aliasp-example";

    [Fact]
    public void BuildRequest_ShouldReturn_ExceptedResult_WhenOptionsNull()
    {
        //arrange
        BaseOptions? options = null;

        //act
        var request = options.BuildRequest(UrlPath, HttpMethod.Get, BrokerAlias);

        //assert
        Assert.NotNull(request);
        Assert.Equal(UrlPath, request.RequestUri!.ToString());
        Assert.Equal(HttpMethod.Get, request.Method);
        Assert.True(request.Options.TryGetValue(new HttpRequestOptionsKey<string>(BridgewayDefaults.BrokerRequestOptionKey), out var option) && option == BrokerAlias);
    }

    [Fact]
    public void BuildRequest_ShouldThrow_NotSupportedException()
    {
        //arrange
        var options = new NotEncodableOptions();

        //act
        Action action = () => options.BuildRequest(UrlPath, HttpMethod.Get, BrokerAlias);

        //assert
        Assert.Throws<NotSupportedException>(action);
    }
}
