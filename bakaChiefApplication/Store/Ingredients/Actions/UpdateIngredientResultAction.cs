using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class UpdateIngredientResultAction
    {
        public Models.Ingredient Ingredient { get; }

        public UpdateIngredientResultAction(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
