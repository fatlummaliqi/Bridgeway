using System.Text.Json.Serialization;

namespace Bridgeway.Test.Unit.Helpers.Options;

public class JsonEncodedOptions : BaseOptions, IJsonEncoded
{
    public string? AdditionalProperty1 { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int AdditionalProperty2 { get; set; }

    [JsonPropertyName("additional_property_3")]
    public double AdditionalProperty3 { get; set; }

    [JsonPropertyName("additional_property_4")]
    public bool AdditionalProperty4 { get; set; }
}
