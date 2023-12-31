using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class UpdateIngredientSucceedAction
{
    public Ingredient UpdatedIngredient { get; set; }

    public UpdateIngredientSucceedAction(Ingredient updatedIngredient)
    {
        UpdatedIngredient = updatedIngredient;
    }
}