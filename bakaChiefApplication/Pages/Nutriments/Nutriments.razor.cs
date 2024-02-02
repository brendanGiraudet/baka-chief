﻿using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.Nutriments;

public partial class Nutriments
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }
    
    [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

    private async Task RedirectToNutrimentForm(FormMode formMode, string? nutrimentId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetNutrimentFormUrl(formMode, nutrimentId));

        await Task.CompletedTask;
    }

    private void ShowMoreNutriments() => Dispatcher.Dispatch(new AddMoreNutrimentsAction(NutrimentsState.Value.NutrimentSearchTerm, SearchConfiguration.DefaultNumberOfItemsToTake, NutrimentsState.Value.Nutriments.Count()));
}
