using Bridgeway.Test.Acceptance.Brokers.Dtos;
using Bridgeway.Test.Acceptance.Brokers.Options;

namespace Bridgeway.Test.Acceptance.Brokers;

[BrokerAlias("JsonPlaceholder")]
public class JsonPlaceholderBroker(IHttpClientFactory httpClientFactory) : Broker(httpClientFactory), IJsonPlaceholderBroker
{
    public Task<TodoDto> CreateTodoAsync(UpsertTodoOptions options, CancellationToken cancellationToken = default)
    {
        return RequestAsync<TodoDto>("/todos", HttpMethod.Post, options, cancellationToken);
    }

    public async Task<bool> DeleteTodoAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await RequestAsync($"/todos/{id}", HttpMethod.Delete, options: null, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public Task<IList<TodoDto>> GetAllAsync(GetTodoOptions options, CancellationToken cancellationToken = default)
    {
        return RequestAsync<IList<TodoDto>>("/todos", HttpMethod.Get, options, cancellationToken);
    }

    public Task<TodoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return RequestAsync<TodoDto>($"/todos/{id}", HttpMethod.Get, options: null, cancellationToken);
    }

    public Task<TodoDto> UpdateAsync(int id, UpsertTodoOptions options, CancellationToken cancellationToken = default)
    {
        return RequestAsync<TodoDto>($"/todos/{id}", HttpMethod.Put, options, cancellationToken);
    }
}
