namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class CreateIngredientAction
    {
        public Models.Ingredient Ingredient { get; }

        public CreateIngredientAction(Models.Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
