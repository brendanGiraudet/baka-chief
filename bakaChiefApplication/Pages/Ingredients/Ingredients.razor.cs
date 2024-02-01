using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Ingredients;

public partial class Ingredients
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    
    [Inject] public IDispatcher Dispatcher { get; set; }
    
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    private async Task RedirectToIngredientForm(FormMode formMode, string? ingredientId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetIngredientFormUrl(formMode, ingredientId));
        
        await Task.CompletedTask;
    }

    private void ShowMoreIngredients() => Dispatcher.Dispatch(new AddMoreIngredientsAction(IngredientsState.Value.IngredientSearchTerm, SearchConstants.DefaultNumberOfItemsToTake, IngredientsState.Value.Ingredients.Count()));
}
