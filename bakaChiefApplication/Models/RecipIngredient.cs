﻿using System.Text.Json.Serialization;

namespace bakaChiefApplication.Models;

public class RecipIngredient
{
    [JsonPropertyName("ingredient")]
    public Ingredient? Ingredient { get; set; }

    [JsonPropertyName("ingredientId")]
    public string IngredientId { get; set; } = string.Empty;

    [JsonPropertyName("recip")]
    public Recip? Recip { get; set; }
    [JsonPropertyName("recipId")]
    public string RecipId { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; }

    [JsonPropertyName("measureUnit")]
    public string MeasureUnit { get; set; } = string.Empty;
}