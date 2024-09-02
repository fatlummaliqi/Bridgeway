using Bridgeway.Test.Acceptance.Brokers.Dtos;
using Bridgeway.Test.Acceptance.Brokers.Options;

namespace Bridgeway.Test.Acceptance.Brokers;

public interface IJsonPlaceholderBroker
{
    Task<TodoDto> CreateTodoAsync(UpsertTodoOptions options, CancellationToken cancellationToken = default);

    Task<TodoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<IList<TodoDto>> GetAllAsync(GetTodoOptions options, CancellationToken cancellationToken = default);

    Task<TodoDto> UpdateAsync(int id, UpsertTodoOptions options, CancellationToken cancellationToken = default);

    Task<bool> DeleteTodoAsync(int id, CancellationToken cancellationToken = default);
}
