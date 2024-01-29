namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class RemoveRecipTypeSucceedAction
{
    public string RemovedRecipTypeId { get; }

    public RemoveRecipTypeSucceedAction(string removedRecipTypeId)
    {
        RemovedRecipTypeId = removedRecipTypeId;
    }
}