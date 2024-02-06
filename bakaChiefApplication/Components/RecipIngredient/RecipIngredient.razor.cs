using bakaChiefApplication.Configurations;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.MeasureUnits;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Components.RecipIngredient;

public partial class RecipIngredient
{
    [Inject] public IState<MeasureUnitsState> MeasureUnitsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public Models.RecipIngredient CurrentRecipIngredient { get; set; }

    [Parameter] public Enums.Icon Icon { get; set; }

    [Parameter] public Enums.Size Size { get; set; }

    [Parameter] public Enums.Style Style { get; set; }

    [Parameter] public EventCallback OnIconClickCallback { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new SearchByNameAction<Models.MeasureUnit>(string.Empty, take: SearchConfiguration.MaxNumberOfItemsToTake));
    }

    private async Task OnIconClick()
    {
        if (OnIconClickCallback.HasDelegate) await OnIconClickCallback.InvokeAsync();
    }
}