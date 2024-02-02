namespace bakaChiefApplication.Store.Ingredients.Actions;

public class IngredientSearchByIdResultAction
{
    public Models.Ingredient Ingredient { get; }

    public IngredientSearchByIdResultAction(Models.Ingredient ingredient)
    {
        Ingredient = ingredient;
    }
}