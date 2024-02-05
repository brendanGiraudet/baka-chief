namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class RemoveSelectedRecipHistorySucceedAction
{
    public string RemovedSelectedRecipHistoryId { get; }

    public RemoveSelectedRecipHistorySucceedAction(string removedSelectedRecipHistoryId)
    {
        RemovedSelectedRecipHistoryId = removedSelectedRecipHistoryId;
    }
}