using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class RecipIngredient
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("ingredient")]
        [Required]
        public Ingredient Ingredient { get; set; }

        [JsonPropertyName("quantity")]
        [Required]
        public int? Quantity { get; set; }

        [JsonPropertyName("measureUnit")]
        [Required]
        public string MeasureUnit { get; set; }
    }
}
