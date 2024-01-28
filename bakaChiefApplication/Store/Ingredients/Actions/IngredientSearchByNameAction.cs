namespace bakaChiefApplication.Store.Ingredients.Actions;

public class IngredientSearchByNameAction
{
    public string IngredientSearchTerm { get; }
    public int Take { get; }

    public IngredientSearchByNameAction(string ingredientSearchTerm, int take)
    {
        IngredientSearchTerm = ingredientSearchTerm;
        Take = take;
    }
}