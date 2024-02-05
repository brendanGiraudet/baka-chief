namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class SelectedRecipHistorySearchByIdAction
{
    public string SelectedRecipHistoryId { get; }

    public SelectedRecipHistorySearchByIdAction(string selectedRecipHistoryId)
    {
        SelectedRecipHistoryId = selectedRecipHistoryId;
    }
}