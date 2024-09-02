using Bridgeway.Test.Unit.Helpers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Bridgeway.Test.Unit;

public class HttpContentUtilsTests
{
    [Fact]
    public void ProcessPayloadAsync_ShouldThrow_NotSupportedException()
    {
        //arrange
        var httpContent = new StringContent("hello world", Encoding.UTF8, MediaTypeNames.Text.Plain);

        //act
        var action = () => HttpContentUtils.ProcessPayloadAsync(httpContent, destinationType: typeof(string));

        //assert
        Assert.ThrowsAsync<NotSupportedException>(action);
    }

    [Fact]
    public void ProcessPayloadAsync_ShouldThrow_BrokerException()
    {
        //arrange
        var httpContent = new StringContent("invalid json encoding", Encoding.UTF8, MediaTypeNames.Application.Json);

        //act
        var action = () => HttpContentUtils.ProcessPayloadAsync(httpContent, destinationType: typeof(string));

        //assert
        Assert.ThrowsAsync<BrokerException>(action);
    }

    [Fact]
    public async Task ProcessPayloadAsync_ShouldProcess_JsonEncodedPayload()
    {
        //arrange
        var dummyInstance = new DummyClass { AdditionalProperty1 = "hello world", AdditionalProperty2 = 123 };

        var httpContent = new StringContent(JsonSerializer.Serialize(dummyInstance), Encoding.UTF8, MediaTypeNames.Application.Json);

        //act
        var payload = await HttpContentUtils.ProcessPayloadAsync(httpContent, destinationType: typeof(DummyClass)) as DummyClass;

        //assert
        Assert.NotNull(dummyInstance);
        Assert.Equal(dummyInstance.AdditionalProperty1, payload!.AdditionalProperty1);
        Assert.Equal(dummyInstance.AdditionalProperty2, payload!.AdditionalProperty2);
    }
}
