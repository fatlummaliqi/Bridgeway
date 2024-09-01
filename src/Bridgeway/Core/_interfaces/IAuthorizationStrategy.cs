namespace Bridgeway;

public interface IAuthorizationStrategy
{
    ValueTask AuthorizeAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
