using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions;

public class AppendNutrimentIntoIngredientAction
{
    public Models.Nutriment SelectedNutriment { get; set; }

    public AppendNutrimentIntoIngredientAction(Nutriment selectedNutriment)
    {
        SelectedNutriment = selectedNutriment;
    }
}