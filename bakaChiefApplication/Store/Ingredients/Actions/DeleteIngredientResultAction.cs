namespace bakaChiefApplication.Store.Ingredients.Actions
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
