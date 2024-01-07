using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class RemoveIngredientIntoRecipAction
{
    public RecipIngredient RemovedIngredient { get; set; }

    public RemoveIngredientIntoRecipAction(RecipIngredient removedIngredient)
    {
        RemovedIngredient = removedIngredient;
    }
}