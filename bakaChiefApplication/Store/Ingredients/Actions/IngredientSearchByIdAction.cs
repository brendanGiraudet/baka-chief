namespace bakaChiefApplication.Store.Ingredients.Actions;

public class IngredientSearchByIdAction
{
    public string IngredientId { get; }

    public IngredientSearchByIdAction(string ingredientId)
    {
        IngredientId = ingredientId;
    }
}