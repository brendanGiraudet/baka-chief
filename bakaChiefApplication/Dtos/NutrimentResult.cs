using System.Text.Json.Serialization;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Dtos;

public class NutrimentResult
{
    [JsonPropertyName("@data.context")]
    public string Context { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public IEnumerable<Nutriment> Values { get; set; } = Enumerable.Empty<Nutriment>();
}