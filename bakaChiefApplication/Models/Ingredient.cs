using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.Models;

public class Ingredient
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    public double KcalNumber { get; set; }

    public HashSet<Nutriment> Nutriments { get; set; } = new();

    public HashSet<Recip> Recips { get; set; } = new();
}