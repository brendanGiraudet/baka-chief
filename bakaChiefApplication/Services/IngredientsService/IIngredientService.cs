﻿using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.IngredientsService
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetAllIngredientAsync();
        Task<Ingredient> GetIngredientByIdAsync(string id);
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(string id);
    }
}