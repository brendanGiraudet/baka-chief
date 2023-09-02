using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class RecipIngredient
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("ingredient")]
        public Ingredient Ingredient { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("measureUnit")]
        public string MeasureUnit { get; set; }
    }
}
