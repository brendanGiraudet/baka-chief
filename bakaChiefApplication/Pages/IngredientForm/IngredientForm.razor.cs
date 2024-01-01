using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.IngredientForm;

public partial class IngredientForm
{
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Parameter] public string Action { get; set; }
    
    [Parameter] public string Id { get; set; }

    public FormMode FormMode => (FormMode)Enum.Parse(typeof(FormMode), Action);
    
    public bool CanDelete => FormMode == FormMode.Update;

     protected override void OnInitialized()
        {
            base.OnInitialized();

            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new IngredientSearchByIdAction(Id));
                    break;
            }
        }

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
                
            case FormMode.Update:
                Dispatcher.Dispatch(new UpdateIngredientAction(IngredientsState.Value.Ingredient));
                break;
            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.IngredientsPathUrl);
    }

    private async Task RemoveIngredient()
    {
        Dispatcher.Dispatch(new RemoveIngredientAction(IngredientsState.Value.Ingredient.Id));

        NavigationManager.NavigateTo(PagesUrl.IngredientsPathUrl);
    }

    private void UpdateNutrimentSearchTerm(string name)
    {
        Dispatcher.Dispatch(new NutrimentSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateNutrimentSearchTermAction(name));
    }

    private void AddNutriment(Nutriment nutriment)
    {
        Dispatcher.Dispatch(new AppendNutrimentIntoIngredientAction(nutriment));
    }
    private void RemoveNutriment(Nutriment nutriment)
    {
        Dispatcher.Dispatch(new RemoveNutrimentIntoIngredientAction(nutriment));
    }
}
