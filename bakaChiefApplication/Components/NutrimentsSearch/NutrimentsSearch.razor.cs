using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.NutrimentsSearch;

public partial class NutrimentsSearch
{
    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;

    [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;

    [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

    [Parameter] public EventCallback<Nutriment> OnTagClickCallback { get; set; }

    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        searchTerm = NutrimentsState.Value.NutrimentSearchTerm;// Keep search value in the input field after navigation

        Dispatcher.Dispatch(new NutrimentSearchByNameAction(NutrimentsState.Value.NutrimentSearchTerm));
    }

    private void UpdateNutrimentSearchTerm(string name)
    {
        Dispatcher.Dispatch(new NutrimentSearchByNameAction(name));
        Dispatcher.Dispatch(new UpdateNutrimentSearchTermAction(name));
    }

    private async Task OnTagClick(Nutriment clikedNutriment)
    {
        if (OnTagClickCallback.HasDelegate) await OnTagClickCallback.InvokeAsync(clikedNutriment);
    }
}