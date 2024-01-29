using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.RecipTypes;
using bakaChiefApplication.Store.RecipTypes.Actions;
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
                Dispatcher.Dispatch(new RecipTypeSearchByIdAction(Id));
                break;
                
            case FormMode.Creation:
                Dispatcher.Dispatch(new RecipTypeCreationInitialisationAction());
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
                Dispatcher.Dispatch(new CreateRecipTypeAction(RecipTypesState.Value.RecipType));
                break;

            case FormMode.Update:
                Dispatcher.Dispatch(new UpdateRecipTypeAction(RecipTypesState.Value.RecipType));
                break;

            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.RecipTypesPathUrl);
    }

    private void RemoveRecipType()
    {
        Dispatcher.Dispatch(new RemoveRecipTypeAction(RecipTypesState.Value.RecipType.Id));

        NavigationManager.NavigateTo(PagesUrl.RecipTypesPathUrl);
    }
}
