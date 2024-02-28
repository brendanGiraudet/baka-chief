using bakaChiefApplication.Services.SelectedRecipHistoriesService;
using bakaChiefApplication.Store.BaseStore;

namespace bakaChiefApplication.Store.SelectedRecipHistories;

public class SelectedRecipHistoriesEffect : BaseEffect<Models.SelectedRecipHistory>
{
    public SelectedRecipHistoriesEffect(ISelectedRecipHistoriesService selectedRecipHistoriesService) : base(selectedRecipHistoriesService)
    {
    }
}