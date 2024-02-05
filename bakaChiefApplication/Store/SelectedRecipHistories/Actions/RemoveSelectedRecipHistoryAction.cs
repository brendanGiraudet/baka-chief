namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class RemoveSelectedRecipHistoryAction
{
    public string SelectedRecipHistoryIdToRemove { get; }

    public RemoveSelectedRecipHistoryAction(string selectedRecipHistoryIdToRemove)
    {
        SelectedRecipHistoryIdToRemove = selectedRecipHistoryIdToRemove;
    }
}