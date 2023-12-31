namespace bakaChiefApplication.Store.Ingredients.Actions;

public class IngredientSearchByIdAction
{
    public string IngredientSearchTerm { get; }

    public IngredientSearchByIdAction(string ingredientSearchTerm)
    {
        IngredientSearchTerm = ingredientSearchTerm;
    }
}