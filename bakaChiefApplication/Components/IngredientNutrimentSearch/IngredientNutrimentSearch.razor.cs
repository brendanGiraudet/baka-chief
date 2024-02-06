using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Nutriments;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.IngredientNutrimentSearch;

public partial class IngredientNutrimentSearch
{
    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }
    
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<Models.IngredientNutriment> OnIconClickCallback { get; set; }
    
    [Parameter] public string IngredientId { get; set; }
    
    [Parameter] public IEnumerable<string>? ExceptedNutrimentIds { get; set; }
    
    [Parameter] public int Take { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = NutrimentsState.Value.NameToSearch;// Keep search value in the input field after navigation

        if(NutrimentsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new SearchByNameAction<Nutriment>(NutrimentsState.Value.NameToSearch, Take));
    }

    private void UpdateNutrimentSearchTerm(string name)
    {
        Dispatcher.Dispatch(new SearchByNameAction<Nutriment>(name, Take));
        Dispatcher.Dispatch(new UpdateNameToSearchAction<Nutriment>(name));
    }

    private async Task OnTagClick(Models.IngredientNutriment clikedNutriment)
    {
        if (OnIconClickCallback.HasDelegate) await OnIconClickCallback.InvokeAsync(clikedNutriment);
    }
}