using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.IngredientsSearch;

public partial class IngredientsSearch
{
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<Ingredient> OnTagClickCallback { get; set; }
    
    [Parameter] public int Take { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = IngredientsState.Value.IngredientSearchTerm;// Keep search value in the input field after navigation

        if(IngredientsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new IngredientSearchByNameAction(IngredientsState.Value.IngredientSearchTerm, Take));
    }

    private void UpdateIngredientSearchTerm(string name)
    {
        Dispatcher.Dispatch(new IngredientSearchByNameAction(name, Take));
        Dispatcher.Dispatch(new UpdateIngredientSearchTermAction(name));
    }

    private async Task OnTagClick(Ingredient clikedIngredient)
    {
        if (OnTagClickCallback.HasDelegate) await OnTagClickCallback.InvokeAsync(clikedIngredient);
    }
}