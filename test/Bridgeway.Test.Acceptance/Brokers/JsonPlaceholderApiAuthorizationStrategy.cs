namespace Bridgeway.Test.Acceptance.Brokers;

public class JsonPlaceholderApiAuthorizationStrategy : IAuthorizationStrategy
{
    public ValueTask AuthorizeAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Since JSON Placeholder API doesn't have any authorization policy,
        // we are keeping this IAuthorizationStrategy as simple as it is.

        return ValueTask.CompletedTask;
    }
}
