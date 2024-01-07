using System.ComponentModel.DataAnnotations;

namespace bakaChiefApplication.Models;

public class RecipStep
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public int Number { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public Recip Recip { get; set; } = new();
}