namespace bakaChiefApplication.Store.Ingredients.Actions;

public class IngredientSearchByNameResultAction
{
    public IEnumerable<Models.Ingredient> SearchedIngredients { get; }

    public IngredientSearchByNameResultAction(IEnumerable<Models.Ingredient> searchedIngredients)
    {
        SearchedIngredients = searchedIngredients;
    }
}