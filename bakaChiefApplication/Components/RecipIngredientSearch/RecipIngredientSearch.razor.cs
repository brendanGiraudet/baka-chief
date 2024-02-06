using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Recips;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.RecipIngredientSearch;

public partial class RecipIngredientSearch
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }
    
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<Models.RecipIngredient> OnIconClickCallback { get; set; }
    
    [Parameter] public string RecipId { get; set; }
    
    [Parameter] public int Take { get; set; } = 10;
    
    [Parameter] public IEnumerable<string>? ExceptedIngredientIds { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = IngredientsState.Value.NameToSearch;// Keep search value in the input field after navigation

        if(IngredientsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new SearchByNameAction<Ingredient>(IngredientsState.Value.NameToSearch, Take));
    }

    private void UpdateIngredientSearchTerm(string name)
    {
        Dispatcher.Dispatch(new SearchByNameAction<Ingredient>(name, Take));
        Dispatcher.Dispatch(new UpdateNameToSearchAction<Ingredient>(name));
    }

    private async Task OnTagClick(Models.RecipIngredient clikedIngredient)
    {
        if (OnIconClickCallback.HasDelegate) await OnIconClickCallback.InvokeAsync(clikedIngredient);
    }
}