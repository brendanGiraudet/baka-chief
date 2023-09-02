using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RemoveSelectedIngredientAction
    {
        public Models.RecipIngredient RecipIngredient { get; }

        public RemoveSelectedIngredientAction(RecipIngredient recipIngredient)
        {
            RecipIngredient = recipIngredient;
        }
    }
}
