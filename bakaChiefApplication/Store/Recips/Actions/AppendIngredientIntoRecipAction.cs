using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class AppendIngredientIntoRecipAction
{
    public Models.Ingredient SelectedIngredient { get; set; }

    public AppendIngredientIntoRecipAction(Ingredient selectedIngredient)
    {
        SelectedIngredient = selectedIngredient;
    }
}