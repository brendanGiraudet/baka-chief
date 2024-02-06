using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.IngredientForm;

public partial class IngredientForm
{
    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }
    
    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    [Parameter] public string Action { get; set; }

    [Parameter] public string Id { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

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

            case FormMode.Creation:
                Dispatcher.Dispatch(new IngredientCreationInitialisationAction());
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
        Dispatcher.Dispatch(new SearchByNameAction<Nutriment>(name, SearchConfiguration.DefaultNumberOfItemsToTake));
        Dispatcher.Dispatch(new UpdateNameToSearchAction<Nutriment>(name));
    }

    private void AddNutriment(IngredientNutriment ingredientNutriment) => Dispatcher.Dispatch(new AppendNutrimentIntoIngredientAction(ingredientNutriment));

    private void RemoveNutriment(IngredientNutriment ingredientNutriment) => Dispatcher.Dispatch(new RemoveNutrimentIntoIngredientAction(ingredientNutriment));
}
