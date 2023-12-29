using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.IngredientForm;

public partial class IngredientForm
{
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public string Action { get; set; }
    
    [Parameter] public string Id { get; set; }

    public FormMode FormMode => (FormMode)Enum.Parse(typeof(FormMode), Action);

    private async Task RedirectToIngredientsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.IngredientsPathUrl);
    }

    private async Task SaveIngredient()
    {
        switch (FormMode)
        {
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreateIngredientAction(IngredientsState.Value.Ingredient));
                break;
            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.IngredientsPathUrl);
    }
}
