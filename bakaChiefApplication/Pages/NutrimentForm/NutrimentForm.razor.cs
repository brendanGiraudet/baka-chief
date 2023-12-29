using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.NutrimentForm;

public partial class NutrimentForm
{
    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public string Action { get; set; }

    public FormMode FormMode => (FormMode)Enum.Parse(typeof(FormMode), Action);

    private async Task RedirectToNutrimentsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.NutrimentsPathUrl);
    }

    private async Task SaveNutriment()
    {
        switch (FormMode)
        {
            case FormMode.Creation:
                Dispatcher.Dispatch(new CreateNutrimentAction(NutrimentsState.Value.Nutriment));
                break;
            default:
                break;
        }

        NavigationManager.NavigateTo(PagesUrl.NutrimentsPathUrl);
    }
}
