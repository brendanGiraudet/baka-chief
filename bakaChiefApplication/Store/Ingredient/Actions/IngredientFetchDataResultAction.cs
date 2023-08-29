namespace bakaChiefApplication.Store.Ingredient.Actions
{
    public class IngredientFetchDataResultAction
    {
        public IEnumerable<Models.Ingredient> Ingredients { get; }

        public IngredientFetchDataResultAction(IEnumerable<Models.Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
