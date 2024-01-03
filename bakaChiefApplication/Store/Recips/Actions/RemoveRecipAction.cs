namespace bakaChiefApplication.Store.Recips.Actions;

public class RemoveRecipAction
{
    public string RecipIdToRemove { get; }

    public RemoveRecipAction(string recipIdToRemove)
    {
        RecipIdToRemove = recipIdToRemove;
    }
}