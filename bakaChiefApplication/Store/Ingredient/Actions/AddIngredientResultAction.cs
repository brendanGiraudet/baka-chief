namespace bakaChiefApplication.Store.Ingredient.Actions
{
    public class AddIngredientResultAction
    {
        public Models.Ingredient Ingredient { get; }

        public AddIngredientResultAction(Models.Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
