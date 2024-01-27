namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class SelectedRecipHistoryFetchAction
{
    public string SelectedRecipHistoryId { get; }

    public SelectedRecipHistoryFetchAction(string selectedRecipHistoryId)
    {
        SelectedRecipHistoryId = selectedRecipHistoryId;
    }
}