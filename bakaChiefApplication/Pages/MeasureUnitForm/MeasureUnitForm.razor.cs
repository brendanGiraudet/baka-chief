using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.MeasureUnits;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.MeasureUnitForm;

public partial class MeasureUnitForm
{
    [Inject] public IState<MeasureUnitsState> MeasureUnitsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

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
                Dispatcher.Dispatch(new SearchByIdAction<MeasureUnit>(Id));
                break;
                
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreationInitialisationAction<MeasureUnit>());
                break;
        }
    }

    private async Task RedirectToMeasureUnitsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.MeasureUnitsPathUrl);
    }

    private async Task SaveMeasureUnit()
    {
        switch (FormMode)
        {
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreateAction<MeasureUnit>(MeasureUnitsState.Value.Item));
                break;

            case FormMode.Update:
                Dispatcher.Dispatch(new UpdateAction<MeasureUnit>(MeasureUnitsState.Value.Item, MeasureUnitsState.Value.Item.Id));
                break;

            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.MeasureUnitsPathUrl);
    }

    private void DeleteMeasureUnit()
    {
        Dispatcher.Dispatch(new DeleteAction<MeasureUnit>(MeasureUnitsState.Value.Item.Id));

        NavigationManager.NavigateTo(PagesUrl.MeasureUnitsPathUrl);
    }
}
