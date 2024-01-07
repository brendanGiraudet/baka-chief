using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class AppendNutrimentIntoIngredientAction
{
    public IngredientNutriment SelectedNutriment { get; set; }

    public AppendNutrimentIntoIngredientAction(IngredientNutriment selectedNutriment)
    {
        SelectedNutriment = selectedNutriment;
    }
}