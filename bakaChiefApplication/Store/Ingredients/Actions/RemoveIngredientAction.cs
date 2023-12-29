namespace bakaChiefApplication.Store.Ingredients.Actions;

public class RemoveIngredientAction
{
    public string IngredientIdToRemove { get; }

    public RemoveIngredientAction(string ingredientIdToRemove)
    {
        IngredientIdToRemove = ingredientIdToRemove;
    }
}