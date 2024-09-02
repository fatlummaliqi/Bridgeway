
namespace Bridgeway.Test.Integration.Helpers;

public class DummyAuthorizationStrategy : IAuthorizationStrategy
{
    public ValueTask AuthorizeAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return ValueTask.CompletedTask;
    }
}
