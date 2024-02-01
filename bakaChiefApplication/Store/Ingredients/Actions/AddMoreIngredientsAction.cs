namespace bakaChiefApplication.Store.Ingredients.Actions;

public class AddMoreIngredientsAction
{
    public string IngredientsearchTerm { get; }
    
    public int Take { get; }
    
    public int Skip { get; }

    public AddMoreIngredientsAction(string ingredientsearchTerm, int take, int skip)
    {
        IngredientsearchTerm = ingredientsearchTerm;
        Take = take;
        Skip = skip;
    }
}