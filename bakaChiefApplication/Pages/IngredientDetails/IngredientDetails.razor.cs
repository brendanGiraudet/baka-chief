using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Nutriments;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.IngredientDetails;

public partial class IngredientDetails
{
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Parameter] public string Id { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new IngredientSearchByIdAction(Id));
    }

    private async Task RedirectToIngredientsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.IngredientsPathUrl);
    }

    private async Task RedirectToIngredientForm(string? ingredientId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetIngredientFormUrl(FormMode.Update, ingredientId));
        
        await Task.CompletedTask;
    }
}
