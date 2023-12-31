using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class UpdateIngredientAction
{
    public Ingredient IngredientToUpdate { get; set; }

    public UpdateIngredientAction(Ingredient ingredientToUpdate)
    {
        IngredientToUpdate = ingredientToUpdate;
    }
}