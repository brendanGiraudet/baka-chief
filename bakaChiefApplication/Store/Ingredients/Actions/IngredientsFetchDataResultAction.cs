namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class IngredientsFetchDataResultAction
    {
        public IEnumerable<Models.Ingredient> Ingredients { get; }

        public IngredientsFetchDataResultAction(IEnumerable<Models.Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
