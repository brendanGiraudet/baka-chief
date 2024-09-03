using bakaChiefApplication.Models;
using bakaChiefApplication.Resources;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.MeasureUnits;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace bakaChiefApplication.Components.MeasureUnitsSearch;

public partial class MeasureUnitsSearch
{
    [Inject] public IStringLocalizer<LabelTranslations> LabelTranslationsLocalizer { get; set; }

    [Inject] public IState<MeasureUnitsState> MeasureUnitsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<MeasureUnit> OnTagClickCallback { get; set; }

    [Parameter] public int Take { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = MeasureUnitsState.Value.NameToSearch;// Keep search value in the input field after navigation

        if(MeasureUnitsState.Value.NeedToReload ?? true)
            Dispatcher.Dispatch(new SearchByNameAction<Models.MeasureUnit>(MeasureUnitsState.Value.NameToSearch, Take));
    }

    private void UpdateMeasureUnitSearchTerm(string name)
    {
        Dispatcher.Dispatch(new SearchByNameAction<MeasureUnit>(name, Take));
        Dispatcher.Dispatch(new UpdateNameToSearchAction<MeasureUnit>(name));
    }

    private async Task OnTagClick(MeasureUnit clikedMeasureUnit)
    {
        if (OnTagClickCallback.HasDelegate) await OnTagClickCallback.InvokeAsync(clikedMeasureUnit);
    }
}