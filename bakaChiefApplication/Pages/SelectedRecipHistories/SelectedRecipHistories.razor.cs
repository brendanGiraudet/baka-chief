using bakaChiefApplication.Store.SelectedRecipHistories;
using bakaChiefApplication.Store.SelectedRecipHistories.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.SelectedRecipHistories;

public partial class SelectedRecipHistories
{
    [Inject] public IState<SelectedRecipHistoriesState> SelectedRecipHistoriesState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Dispatcher.Dispatch(new SelectedRecipHistoriesFetchAction());
    }

    private async Task GenerateSelectedRecipHistory()
    {
        await Task.CompletedTask;
    }
}