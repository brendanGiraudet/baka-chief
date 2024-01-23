using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
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

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = NutrimentsState.Value.NutrimentSearchTerm;// Keep search value in the input field after navigation

        if(NutrimentsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new NutrimentSearchByNameAction(NutrimentsState.Value.NutrimentSearchTerm));
    }

    private void UpdateNutrimentSearchTerm(string name)
    {
        Dispatcher.Dispatch(new NutrimentSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateNutrimentSearchTermAction(name));
    }

    private async Task OnTagClick(Models.IngredientNutriment clikedNutriment)
    {
        if (OnIconClickCallback.HasDelegate) await OnIconClickCallback.InvokeAsync(clikedNutriment);
    }
}