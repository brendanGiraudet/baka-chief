using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models;

public class Nutriment
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("ingredientNutriments")]
    public ICollection<IngredientNutriment> IngredientNutriments { get; set; } = new HashSet<IngredientNutriment>();
}