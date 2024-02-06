using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Recips;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.RecipsSearch;

public partial class RecipsSearch
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<Recip> OnTagClickCallback { get; set; }

    [Parameter] public int Take { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = RecipsState.Value.NameToSearch;// Keep search value in the input field after navigation

        if(RecipsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new SearchByNameAction<Recip>(RecipsState.Value.NameToSearch, Take));
    }

    private void UpdateRecipSearchTerm(string name)
    {
        Dispatcher.Dispatch(new SearchByNameAction<Recip>(name, Take));
        Dispatcher.Dispatch(new UpdateNameToSearchAction<Recip>(name));
    }

    private async Task OnTagClick(Recip clikedRecip)
    {
        if (OnTagClickCallback.HasDelegate) await OnTagClickCallback.InvokeAsync(clikedRecip);
    }
}