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

    private string searchTerm;

    private void UpdateNutrimentSearchTerm(string name)
    {
        Dispatcher.Dispatch(new NutrimentSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateNutrimentSearchTermAction(name));
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = NutrimentsState.Value.NutrimentSearchTerm;// Keep search value in the input field after navigation

        Dispatcher.Dispatch(new NutrimentSearchByNameAction(NutrimentsState.Value.NutrimentSearchTerm));
    }
}
