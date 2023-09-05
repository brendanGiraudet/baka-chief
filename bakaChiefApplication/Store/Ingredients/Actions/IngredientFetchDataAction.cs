using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class IngredientFetchDataAction
    {
        public string IngredientId { get; }

        public IngredientFetchDataAction(string ingredientId)
        {
            IngredientId = ingredientId;
        }
    }
}
