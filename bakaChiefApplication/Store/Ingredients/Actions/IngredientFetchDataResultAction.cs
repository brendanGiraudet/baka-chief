namespace bakaChiefApplication.Store.Ingredients.Actions
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
