using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class AddSelectedIngredientAction
    {
        public Models.Ingredient Ingredient { get; }

        public AddSelectedIngredientAction(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
