using System.Text.Json.Serialization;

namespace Bridgeway.Test.Unit.Helpers.Options;

public class NotEncodableOptions : BaseOptions
{
    public string? AdditionalProperty1 { get; set; }

    [JsonIgnore]
    public int AdditionalProperty2 { get; set; }

    [JsonPropertyName("additional_property_3")]
    public double AdditionalProperty3 { get; set; }

    [JsonPropertyName("additional_property_4")]
    public bool AdditionalProperty4 { get; set; }
}
