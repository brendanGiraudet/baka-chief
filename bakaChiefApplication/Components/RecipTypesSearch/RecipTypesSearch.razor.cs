using bakaChiefApplication.Models;
using bakaChiefApplication.Store.RecipTypes;
using bakaChiefApplication.Store.RecipTypes.Actions;
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

        searchTerm = RecipTypesState.Value.RecipTypeSearchTerm;// Keep search value in the input field after navigation

        if(RecipTypesState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new RecipTypeSearchByNameAction(RecipTypesState.Value.RecipTypeSearchTerm));
    }

    private void UpdateRecipTypeSearchTerm(string name)
    {
        Dispatcher.Dispatch(new RecipTypeSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateRecipTypeSearchTermAction(name));
    }

    private async Task OnTagClick(RecipType clikedRecipType)
    {
        if (OnTagClickCallback.HasDelegate) await OnTagClickCallback.InvokeAsync(clikedRecipType);
    }
}