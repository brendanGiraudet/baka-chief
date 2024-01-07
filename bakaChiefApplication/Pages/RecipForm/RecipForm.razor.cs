using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.RecipForm;

public partial class RecipForm
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

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
                Dispatcher.Dispatch(new RecipSearchByIdAction(Id));
                break;
        }
    }

    private async Task RedirectToRecipsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private async Task SaveRecip()
    {
        switch (FormMode)
        {
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreateRecipAction(RecipsState.Value.Recip));
                break;

            case FormMode.Update:
                Dispatcher.Dispatch(new UpdateRecipAction(RecipsState.Value.Recip));
                break;
            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private async Task RemoveRecip()
    {
        Dispatcher.Dispatch(new RemoveRecipAction(RecipsState.Value.Recip.Id));

        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private void UpdateIngredientSearchTerm(string name)
    {
        Dispatcher.Dispatch(new IngredientSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateIngredientSearchTermAction(name));
    }

    private void AddIngredient(Ingredient ingredient)
    {
        RecipIngredient recipIngredient = CreateRecipIngredient(ingredient);

        Dispatcher.Dispatch(new AppendIngredientIntoRecipAction(recipIngredient));
    }

    private RecipIngredient CreateRecipIngredient(Ingredient ingredient)
    {
        return new RecipIngredient
        {
            IngredientId = ingredient.Id,
            Ingredient = ingredient,
            RecipId = RecipsState.Value.Recip.Id
        };
    }

    private void RemoveIngredient(Ingredient ingredient)
    {
        RecipIngredient recipIngredient = CreateRecipIngredient(ingredient);

        Dispatcher.Dispatch(new RemoveIngredientIntoRecipAction(recipIngredient));
    }
}
