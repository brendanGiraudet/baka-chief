using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class SelectedRecipHistoriesFetchResultAction
{
    public IEnumerable<SelectedRecipHistory> SelectedRecipHistories { get; }

    public SelectedRecipHistoriesFetchResultAction(IEnumerable<SelectedRecipHistory> selectedRecipHistories)
    {
        SelectedRecipHistories = selectedRecipHistories;
    }
}