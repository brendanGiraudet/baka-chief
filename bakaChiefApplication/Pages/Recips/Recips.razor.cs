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

    private string searchTerm;

    private void UpdateRecipSearchTerm(string name)
    {
        Dispatcher.Dispatch(new RecipSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateRecipSearchTermAction(name));
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = RecipsState.Value.RecipSearchTerm;// Keep search value in the input field after navigation

        if(RecipsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new RecipSearchByNameAction(RecipsState.Value.RecipSearchTerm));
    }

    private async Task RedirectToRecipForm(FormMode formMode, string? RecipId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipFormUrl(formMode, RecipId));
    }

    private void RemoveRecip(string id)
    {
        Dispatcher.Dispatch(new RemoveRecipAction(id));
    }

    private void ShowMoreRecip() => Dispatcher.Dispatch(new AddMoreRecipsAction(RecipsState.Value.RecipSearchTerm, Search.DefaultNumberOfItemsToTake, RecipsState.Value.Recips.Count()));
}
