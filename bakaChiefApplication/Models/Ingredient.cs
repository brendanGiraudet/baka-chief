using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class Ingredient
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [JsonPropertyName("nutriments")]
        [Required]
        [MinLength(1)]
        public Nutriment[] Nutriments { get; set; } = Array.Empty<Nutriment>();
    }
}
