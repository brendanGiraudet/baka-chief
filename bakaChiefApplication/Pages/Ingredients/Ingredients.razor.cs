using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Ingredients;

public partial class Ingredients
{
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private string searchTerm;

    private void UpdateIngredientSearchTerm(string name)
    {
        Dispatcher.Dispatch(new IngredientSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateIngredientSearchTermAction(name));
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = IngredientsState.Value.IngredientSearchTerm;// Keep search value in the input field after navigation

        Dispatcher.Dispatch(new IngredientSearchByNameAction(IngredientsState.Value.IngredientSearchTerm));
    }

    private async Task RedirectToIngredientForm(FormMode formMode, string? ingredientId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetIngredientFormUrl(formMode, ingredientId));
    }

    private void RemoveIngredient(string id)
    {
        Dispatcher.Dispatch(new RemoveIngredientAction(id));
    }
}
