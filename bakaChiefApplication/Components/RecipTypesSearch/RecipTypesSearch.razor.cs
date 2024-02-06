using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.RecipTypes;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.RecipTypesSearch;

public partial class RecipTypesSearch
{
    [Inject] public IState<RecipTypesState> RecipTypesState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<RecipType> OnTagClickCallback { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = RecipTypesState.Value.NameToSearch;// Keep search value in the input field after navigation

        if(RecipTypesState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new SearchByNameAction<RecipType>(RecipTypesState.Value.NameToSearch));
    }

    private void UpdateRecipTypeSearchTerm(string name)
    {
        Dispatcher.Dispatch(new SearchByNameAction<RecipType>(name));
        Dispatcher.Dispatch(new UpdateNameToSearchAction<RecipType>(name));
    }

    private async Task OnTagClick(RecipType clikedRecipType)
    {
        if (OnTagClickCallback.HasDelegate) await OnTagClickCallback.InvokeAsync(clikedRecipType);
    }
}