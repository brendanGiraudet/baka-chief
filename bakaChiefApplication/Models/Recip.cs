using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models
{
    public class Recip
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("personsNumber")]
        public int PersonsNumber { get; set; }

        [JsonPropertyName("imageFilePath")]
        public string? ImageFilePath { get; set; }

        [JsonPropertyName("recipIngredients")]
        public ICollection<RecipIngredient> RecipIngredients { get; set; }

        [JsonPropertyName("recipSteps")]
        public ICollection<RecipStep> RecipSteps { get; set; }
    }
}
