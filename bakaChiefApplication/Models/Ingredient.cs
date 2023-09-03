using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class Ingredient
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("nutrimentTypes")]
        public IEnumerable<NutrimentType> NutrimentTypes { get; set; } = Enumerable.Empty<NutrimentType>();
    }
}
