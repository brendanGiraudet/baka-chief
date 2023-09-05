using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class UpdateIngredientAction
    {
        public Models.Ingredient Ingredient { get; }

        public UpdateIngredientAction(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
