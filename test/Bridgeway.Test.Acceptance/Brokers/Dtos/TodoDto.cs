using System.Text.Json.Serialization;

namespace Bridgeway.Test.Acceptance.Brokers.Dtos;

public class TodoDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }
}
