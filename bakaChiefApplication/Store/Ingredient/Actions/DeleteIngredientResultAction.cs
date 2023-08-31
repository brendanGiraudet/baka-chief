namespace bakaChiefApplication.Store.Ingredient.Actions
{
    public class DeleteIngredientResultAction
    {
        public string IngredientId { get; }

        public DeleteIngredientResultAction(string ingredientId)
        {
            IngredientId = ingredientId;
        }
    }
}
