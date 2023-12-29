using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class CreateIngredientAction
{
    public Ingredient IngredientToCreate { get; set; }

    public CreateIngredientAction(Ingredient ingredientToCreate)
    {
        IngredientToCreate = ingredientToCreate;
    }
}