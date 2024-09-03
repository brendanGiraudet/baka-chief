using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Resources;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.RecipTypes;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.RecipTypes;

public partial class RecipTypes
{
    [Inject] public IStringLocalizer<LabelTranslations> LabelTranslationsLocalizer { get; set; }

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

    private void ShowMoreRecipTypes() => Dispatcher.Dispatch(new SearchByNameMoreAction<RecipType>(RecipTypesState.Value.NameToSearch, SearchConfiguration.DefaultNumberOfItemsToTake, RecipTypesState.Value.Items.Count()));
}
