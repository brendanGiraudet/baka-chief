namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class CreateIngredientResultAction
    {
        public Models.Ingredient Ingredient { get; }

        public CreateIngredientResultAction(Models.Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
