using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.RecipTypes;
using bakaChiefApplication.Store.RecipTypes.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.RecipTypes;

public partial class RecipTypes
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<RecipTypesState> RecipTypesState { get; set; }
    
    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

    private async Task RedirectToRecipTypeForm(FormMode formMode, string? RecipTypeId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipTypeFormUrl(formMode, RecipTypeId));

        await Task.CompletedTask;
    }

    private void ShowMoreRecipTypes() => Dispatcher.Dispatch(new AddMoreRecipTypesAction(RecipTypesState.Value.RecipTypeSearchTerm, SearchConfiguration.DefaultNumberOfItemsToTake, RecipTypesState.Value.RecipTypes.Count()));
}
