using Bridgeway.Test.Unit.Helpers.Options;
using System.Text.Json;

namespace Bridgeway.Test.Unit;

public class HttpRequestUtilsTests
{
    public const string UrlPath = "/api/v1/dummy-resource-path";

    [Fact]
    public void BuildUrlEncodedRequest_ShouldReturn_ExceptedRequestMessage()
    {
        //arrange
        const string ExpectedUrlPath = $"{UrlPath}?AdditionalProperty1=placeholder&additional_property_3=12.34&additional_property_4=False&";

        var options = new UrlEncodedOptions
        {
            AdditionalProperty1 = "placeholder",
            AdditionalProperty2 = 123,
            AdditionalProperty3  = 12.34,
            AdditionalProperty4 = false 
        };

        //act
        var request = HttpRequestUtils.BuildUrlEncodedRequest(UrlPath, HttpMethod.Get, options);

        //assert
        Assert.NotNull(request);
        Assert.Equal(ExpectedUrlPath, request.RequestUri!.ToString());
    }

    [Fact]
    public async Task BuildJsonEncodedRequest_ShouldReturn_ExceptedRequestMessage()
    {
        //arrange 
        var options = new JsonEncodedOptions
        {
            AdditionalProperty1 = "placeholder",
            AdditionalProperty2 = 123,
            AdditionalProperty3 = 12.34,
            AdditionalProperty4 = false
        };

        var expectedPayload = JsonSerializer.Serialize(options);

        //act
        var request = HttpRequestUtils.BuildJsonEncodedRequest(UrlPath, HttpMethod.Post, options);

        var a = await request.Content!.ReadAsStringAsync();

        //assert
        Assert.NotNull(request);
        Assert.Equal(expectedPayload, await request.Content!.ReadAsStringAsync());
    }
}
