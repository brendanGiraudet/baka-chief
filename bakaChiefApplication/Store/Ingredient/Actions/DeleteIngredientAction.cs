namespace bakaChiefApplication.Store.Ingredient.Actions
{
    public class DeleteIngredientAction
    {
        public string IngredientId { get; }

        public DeleteIngredientAction(string ingredientId)
        {
            IngredientId = ingredientId;
        }
    }
}
