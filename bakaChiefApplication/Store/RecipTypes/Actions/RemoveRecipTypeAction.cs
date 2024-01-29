namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class RemoveRecipTypeAction
{
    public string RecipTypeIdToRemove { get; }

    public RemoveRecipTypeAction(string recipTypeIdToRemove)
    {
        RecipTypeIdToRemove = recipTypeIdToRemove;
    }
}