namespace bakaChiefApplication.Store.Ingredients.Actions;

public class AddMoreIngredientsResultAction
{
    public IEnumerable<Models.Ingredient> SearchedIngredients { get; }

    public AddMoreIngredientsResultAction(IEnumerable<Models.Ingredient> searchedIngredients)
    {
        SearchedIngredients = searchedIngredients;
    }
}