namespace bakaChiefApplication.Store.Ingredients.Actions;

public class IngredientSearchByNameAction
{
    public string IngredientSearchTerm { get; }

    public IngredientSearchByNameAction(string ingredientSearchTerm)
    {
        IngredientSearchTerm = ingredientSearchTerm;
    }
}