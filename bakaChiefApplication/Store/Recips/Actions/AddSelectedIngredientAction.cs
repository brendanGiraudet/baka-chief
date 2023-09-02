using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class AddSelectedIngredientAction
    {
        public Models.RecipIngredient RecipIngredient { get; }

        public AddSelectedIngredientAction(RecipIngredient recipIngredient)
        {
            RecipIngredient = recipIngredient;
        }
    }
}
