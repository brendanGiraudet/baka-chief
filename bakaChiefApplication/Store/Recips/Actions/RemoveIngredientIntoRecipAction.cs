using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class RemoveIngredientIntoRecipAction
{
    public Models.Ingredient RemovedIngredient { get; set; }

    public RemoveIngredientIntoRecipAction(Ingredient removedIngredient)
    {
        RemovedIngredient = removedIngredient;
    }
}