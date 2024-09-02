using System.Text.Json.Serialization;

namespace Bridgeway.Test.Acceptance.Brokers.Options;

public class UpsertTodoOptions : BaseOptions, IJsonEncoded
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }
}
