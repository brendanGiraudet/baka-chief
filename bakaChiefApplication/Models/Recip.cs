﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models;

public class Recip
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("personsNumber")]
    public int PersonsNumber { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("recipIngredients")]
    public ICollection<RecipIngredient> RecipIngredients { get; set; } = new HashSet<RecipIngredient>();

    [JsonPropertyName("preparation")]
    public string Preparation { get; set; } = string.Empty;

    [JsonPropertyName("recipType")]
    public RecipType? RecipType { get; set; }
    
    [JsonPropertyName("recipTypeId")]
    public string? RecipTypeId { get; set; }
}