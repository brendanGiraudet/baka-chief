namespace bakaChiefApplication.Store.Ingredients.Actions;

public class UpdateIngredientSearchTermAction
{
    public string IngredientSearchTerm { get; set; }

    public UpdateIngredientSearchTermAction(string ingredientSearchTerm)
    {
        IngredientSearchTerm = ingredientSearchTerm;
    }
}