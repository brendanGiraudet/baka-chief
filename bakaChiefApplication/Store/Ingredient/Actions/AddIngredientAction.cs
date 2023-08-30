namespace bakaChiefApplication.Store.Ingredient.Actions
{
    public class AddIngredientAction
    {
        public Models.Ingredient Ingredient { get; }

        public AddIngredientAction(Models.Ingredient ingredient)
        {
            Ingredient = ingredient;
        }
    }
}
