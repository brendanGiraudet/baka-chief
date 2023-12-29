using System.Text.Json.Serialization;

namespace bakaChiefApplication.Dtos;

public class ODataResult<T>
{
    [JsonPropertyName("@data.context")]
    public string Context { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public IEnumerable<T> Value { get; set; } = Enumerable.Empty<T>();
}