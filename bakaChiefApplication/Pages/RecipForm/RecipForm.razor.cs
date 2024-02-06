using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using bakaChiefApplication.Store.Ingredients;
using Fluxor;
using Microsoft.AspNetCore.Components;
using bakaChiefApplication.Store.RecipTypes;
using bakaChiefApplication.Configurations;
using Microsoft.Extensions.Options;
using bakaChiefApplication.Store.BaseStore.Actions;

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
                Dispatcher.Dispatch(new SearchByIdAction<Recip>(Id));
                break;

            case FormMode.Creation:
                Dispatcher.Dispatch(new CreationInitialisationAction<Recip>());
                break;
        }

        Dispatcher.Dispatch(new SearchByNameAction<RecipType>(string.Empty, take:SearchConfiguration.MaxNumberOfItemsToTake));
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
                Dispatcher.Dispatch(new CreateAction<Recip>(RecipsState.Value.Item));
                break;

            case FormMode.Update:
                Dispatcher.Dispatch(new UpdateAction<Recip>(RecipsState.Value.Item, RecipsState.Value.Item.Id));
                break;
            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private async Task RemoveRecip()
    {
        Dispatcher.Dispatch(new DeleteAction<Recip>(RecipsState.Value.Item.Id));

        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private void AddIngredient(RecipIngredient recipIngredient) => Dispatcher.Dispatch(new AppendIngredientIntoRecipAction(recipIngredient));

    private void RemoveIngredient(RecipIngredient recipIngredient) => Dispatcher.Dispatch(new RemoveIngredientIntoRecipAction(recipIngredient));
}
