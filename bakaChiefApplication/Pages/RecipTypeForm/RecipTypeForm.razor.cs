using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.RecipTypes;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.RecipTypeForm;

public partial class RecipTypeForm
{
    [Inject] public IState<RecipTypesState> RecipTypesState { get; set; }

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
                Dispatcher.Dispatch(new SearchByIdAction<RecipType>(Id));
                break;
                
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreationInitialisationAction<RecipType>());
                break;
        }
    }

    private async Task RedirectToRecipTypesPage()
    {
        NavigationManager.NavigateTo(PagesUrl.RecipTypesPathUrl);
    }

    private async Task SaveRecipType()
    {
        switch (FormMode)
        {
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreateAction<RecipType>(RecipTypesState.Value.Item));
                break;

            case FormMode.Update:
                Dispatcher.Dispatch(new UpdateAction<RecipType>(RecipTypesState.Value.Item, RecipTypesState.Value.Item.Id));
                break;

            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.RecipTypesPathUrl);
    }

    private void RemoveRecipType()
    {
        Dispatcher.Dispatch(new DeleteAction<RecipType>(RecipTypesState.Value.Item.Id));

        NavigationManager.NavigateTo(PagesUrl.RecipTypesPathUrl);
    }
}
