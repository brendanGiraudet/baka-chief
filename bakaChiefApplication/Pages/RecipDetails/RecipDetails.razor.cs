using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Ingredients;
using Fluxor;
using Microsoft.AspNetCore.Components;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;

namespace bakaChiefApplication.Pages.RecipDetails;

public partial class RecipDetails
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Parameter] public string Id { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new SearchByIdAction<Recip>(Id));
    }

    private async Task RedirectToRecipsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private async Task RedirectToRecipForm(string? RecipId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipFormUrl(FormMode.Update, RecipId));
        
        await Task.CompletedTask;
    }

    private async Task RedirectToIngredientDetails(string ingredientId)
    {
        NavigationManager.NavigateTo(PagesUrl.GetIngredientDetailsUrl(ingredientId));
        
        await Task.CompletedTask;
    }
}