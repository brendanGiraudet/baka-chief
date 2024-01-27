using bakaChiefApplication.Services.SelectedRecipHistoriesService;
using bakaChiefApplication.Store.SelectedRecipHistories.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.SelectedRecipHistories;

public class SelectedRecipHistoriesEffect
{
    private ISelectedRecipHistoriesService _selectedRecipHistoriesService;

    public SelectedRecipHistoriesEffect(ISelectedRecipHistoriesService selectedRecipHistoriesService)
    {
        _selectedRecipHistoriesService = selectedRecipHistoriesService;
    }

    [EffectMethod]
    public async Task HandleSelectedRecipHistoriesFetchAction(SelectedRecipHistoriesFetchAction action, IDispatcher dispatcher)
    {
        var selectedRecipHistoriesResponse = await _selectedRecipHistoriesService.GetSelectedRecipHistoriesAsync();

        if (!selectedRecipHistoriesResponse.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new SelectedRecipHistoriesFetchResultAction(selectedRecipHistoriesResponse.Value));
    }
}