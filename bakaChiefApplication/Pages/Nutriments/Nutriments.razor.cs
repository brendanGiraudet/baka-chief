using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Nutriments;

public partial class Nutriments
{
    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private async Task RedirectToNutrimentForm(FormMode formMode)
    {
        NavigationManager.NavigateTo(PagesUrl.GetNutrimentFormUrl(formMode));
    }

    private void RemoveNutriment(string id)
    {
        Dispatcher.Dispatch(new RemoveNutrimentAction(id));
    }
}
