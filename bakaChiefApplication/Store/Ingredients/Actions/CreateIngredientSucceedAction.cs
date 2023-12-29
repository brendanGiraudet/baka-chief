using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class CreateIngredientSucceedAction
{
    public Ingredient CreatedIngredient { get; set; }

    public CreateIngredientSucceedAction(Ingredient createdIngredient)
    {
        CreatedIngredient = createdIngredient;
    }
}