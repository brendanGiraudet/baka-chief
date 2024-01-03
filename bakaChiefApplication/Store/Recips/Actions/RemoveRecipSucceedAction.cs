namespace bakaChiefApplication.Store.Recips.Actions;

public class RemoveRecipSucceedAction
{
    public string RemovedRecipId { get; }

    public RemoveRecipSucceedAction(string removedRecipId)
    {
        RemovedRecipId = removedRecipId;
    }
}