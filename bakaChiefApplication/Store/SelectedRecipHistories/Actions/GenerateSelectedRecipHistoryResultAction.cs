using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.SelectedRecipHistories.Actions;

public class GenerateSelectedRecipHistoryResultAction
{
    public SelectedRecipHistory GeneratedSelectedRecipHistory { get; }

    public GenerateSelectedRecipHistoryResultAction(SelectedRecipHistory generatedSelectedRecipHistory)
    {
        GeneratedSelectedRecipHistory = generatedSelectedRecipHistory;
    }
}