using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Resources;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Nutriments;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.Nutriments;

public partial class Nutriments
{
    [Inject] public IStringLocalizer<LabelTranslations> LabelTranslationsLocalizer { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

    private async Task RedirectToNutrimentForm(FormMode formMode, string? nutrimentId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetNutrimentFormUrl(formMode, nutrimentId));

        await Task.CompletedTask;
    }

    private void ShowMoreNutriments() => Dispatcher.Dispatch(new SearchByNameMoreAction<Models.Nutriment>(NutrimentsState.Value.NameToSearch, SearchConfiguration.DefaultNumberOfItemsToTake, NutrimentsState.Value.Items.Count()));
}
