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

    private async Task RedirectToIngredientDetails(string ingredientId)
    {
        NavigationManager.NavigateTo(PagesUrl.GetIngredientDetailsUrl(ingredientId));
        
        await Task.CompletedTask;
    }

    private async Task RedirectToIngredientForm()
    {
        NavigationManager.NavigateTo(PagesUrl.GetIngredientFormUrl(FormMode.Creation));
        
        await Task.CompletedTask;
    }

    private void ShowMoreIngredients() => Dispatcher.Dispatch(new AddMoreIngredientsAction(IngredientsState.Value.IngredientSearchTerm, SearchConstants.DefaultNumberOfItemsToTake, IngredientsState.Value.Ingredients.Count()));
}
