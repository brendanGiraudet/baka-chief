using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class AppendIngredientIntoRecipAction
{
    public RecipIngredient SelectedIngredient { get; set; }

    public AppendIngredientIntoRecipAction(RecipIngredient selectedIngredient)
    {
        SelectedIngredient = selectedIngredient;
    }
}