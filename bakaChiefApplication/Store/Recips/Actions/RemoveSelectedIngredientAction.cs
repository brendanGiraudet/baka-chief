using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RemoveSelectedIngredientAction
    {
        public Models.Ingredient Ingredient { get; }

        public RemoveSelectedIngredientAction(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
