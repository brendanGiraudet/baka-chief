using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Recips;

public partial class Recips
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private async Task RedirectToRecipDetails(string recipId)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipDetailsUrl(recipId));
        
        await Task.CompletedTask;
    }

    private async Task RedirectToRecipForm()
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipFormUrl(FormMode.Creation));
        
        await Task.CompletedTask;
    }

    private void ShowMoreRecip() => Dispatcher.Dispatch(new AddMoreRecipsAction(RecipsState.Value.RecipSearchTerm, SearchConstants.DefaultNumberOfItemsToTake, RecipsState.Value.Recips.Count()));
}
