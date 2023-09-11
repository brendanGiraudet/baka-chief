using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class Recip
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("personsNumber")]
        [Required]
        public int? PersonsNumber { get; set; }

        [JsonPropertyName("imageFilePath")]
        [Required]
        public string? ImageFilePath { get; set; }

        [JsonPropertyName("recipIngredients")]
        [Required]
        [MinLength(1)]
        public RecipIngredient[] RecipIngredients { get; set; } = Array.Empty<RecipIngredient>();

        [JsonPropertyName("recipSteps")]
        [Required]
        [MinLength(1)]
        public RecipStep[] RecipSteps { get; set; } = Array.Empty<RecipStep>();
    }
}
