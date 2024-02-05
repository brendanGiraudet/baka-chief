using bakaChiefApplication.Constants;
using bakaChiefApplication.Store.SelectedRecipHistories;
using bakaChiefApplication.Store.SelectedRecipHistories.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.SelectedRecipHistory;

public partial class SelectedRecipHistory
{
    [Inject] public IState<SelectedRecipHistoriesState> SelectedRecipHistoriesState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public string Id { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        
        Dispatcher.Dispatch(new SelectedRecipHistorySearchByIdAction(Id));
    }

    private async Task RedirectToRecipDetailsPage(string id)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipDetailsUrl(id));
    }
}