using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.Models;

public class Nutriment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Name { get; set; } = string.Empty;

    public HashSet<Ingredient> Ingredients { get; set; } = new();
}