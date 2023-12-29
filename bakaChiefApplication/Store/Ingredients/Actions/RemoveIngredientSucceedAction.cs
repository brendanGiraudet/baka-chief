namespace bakaChiefApplication.Store.Ingredients.Actions;

public class RemoveIngredientSucceedAction
{
    public string RemovedIngredientId { get; }

    public RemoveIngredientSucceedAction(string removedIngredientId)
    {
        RemovedIngredientId = removedIngredientId;
    }
}