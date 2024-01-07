using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class RemoveNutrimentIntoIngredientAction
{
    public IngredientNutriment RemovedNutriment { get; set; }

    public RemoveNutrimentIntoIngredientAction(IngredientNutriment removedNutriment)
    {
        RemovedNutriment = removedNutriment;
    }
}