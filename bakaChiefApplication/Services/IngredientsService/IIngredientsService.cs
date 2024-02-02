using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.IngredientsService;

public interface IIngredientsService
{
    /// <summary>
    /// Get Ingredients with limit
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();

    /// <summary>
    /// Get Ingredients search by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<IEnumerable<Ingredient>> GetIngredientsByNameAsync(string name, int? take = null, int? skip = null);

    /// <summary>
    /// Create a Ingredient
    /// </summary>
    /// <param name="ingredient">Ingredient info</param>
    /// <returns></returns>
    Task<MethodResult<Ingredient>> CreateIngredientAsync(Ingredient ingredient);

    /// <summary>
    /// Delete specific Ingredient
    /// </summary>
    /// <param name="ingredientIdToRemove"></param>
    /// <returns></returns>
    Task<MethodResult<string>> RemoveIngredientAsync(string ingredientIdToRemove);

    /// <summary>
    /// Update an ingredient
    /// </summary>
    /// <param name="ingredientToUpdate"></param>
    /// <returns></returns>
    Task<MethodResult<Ingredient>> UpdateIngredientAsync(Ingredient ingredientToUpdate);

    /// <summary>
    /// Get ingredient by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<MethodResult<Ingredient>> GetIngredientsByIdAsync(string id);
}