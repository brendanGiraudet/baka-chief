using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using bakaChiefApplication.Store.Ingredients;
using Fluxor;
using Microsoft.AspNetCore.Components;
using bakaChiefApplication.Store.RecipTypes;
using bakaChiefApplication.Store.RecipTypes.Actions;
using bakaChiefApplication.Configurations;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.RecipForm;

public partial class RecipForm
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }
    
    [Inject] public IState<RecipTypesState> RecipTypesState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

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

            case FormMode.Creation:
                Dispatcher.Dispatch(new RecipCreationInitialisationAction());
                break;
        }

        Dispatcher.Dispatch(new RecipTypeSearchByNameAction(string.Empty));
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

    private void AddIngredient(RecipIngredient recipIngredient) => Dispatcher.Dispatch(new AppendIngredientIntoRecipAction(recipIngredient));

    private void RemoveIngredient(RecipIngredient recipIngredient) => Dispatcher.Dispatch(new RemoveIngredientIntoRecipAction(recipIngredient));
}
