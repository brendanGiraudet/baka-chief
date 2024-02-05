using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class SelectedRecipHistorySearchByIdResultAction
{
    public Models.SelectedRecipHistory SelectedRecipHistory { get; }

    public SelectedRecipHistorySearchByIdResultAction(SelectedRecipHistory selectedRecipHistory)
    {
        SelectedRecipHistory = selectedRecipHistory;
    }
}