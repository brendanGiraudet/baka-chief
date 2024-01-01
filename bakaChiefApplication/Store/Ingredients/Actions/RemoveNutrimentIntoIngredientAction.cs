using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class RemoveNutrimentIntoIngredientAction
{
    public Models.Nutriment RemovedNutriment { get; set; }

    public RemoveNutrimentIntoIngredientAction(Nutriment removedNutriment)
    {
        RemovedNutriment = removedNutriment;
    }
}