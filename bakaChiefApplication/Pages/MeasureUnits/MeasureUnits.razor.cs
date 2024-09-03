using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Resources;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.MeasureUnits;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.MeasureUnits;

public partial class MeasureUnits
{
    [Inject] public IStringLocalizer<LabelTranslations> LabelTranslationsLocalizer { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }
    
    [Inject] public IState<MeasureUnitsState> MeasureUnitsState { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

    private async Task RedirectToMeasureUnitForm(FormMode formMode, string? MeasureUnitId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetMeasureUnitFormUrl(formMode, MeasureUnitId));

        await Task.CompletedTask;
    }
    
    private void ShowMoreMeasureUnits() => Dispatcher.Dispatch(new SearchByNameMoreAction<Models.MeasureUnit>(MeasureUnitsState.Value.NameToSearch, SearchConfiguration.DefaultNumberOfItemsToTake, MeasureUnitsState.Value.Items.Count()));
}
