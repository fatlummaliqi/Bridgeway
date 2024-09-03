namespace Bridgeway;

/// <summary>
/// Defines a contract for authorization strategies.
/// </summary>
public interface IAuthorizationStrategy
{
    /// <summary>
    /// Asynchronously authorizes a request.
    /// </summary>
    /// <param name="request">
    /// The HTTP request message that requires authorization.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to observe and respond to cancellation requests.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation.
    /// </returns>
    ValueTask AuthorizeAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}
