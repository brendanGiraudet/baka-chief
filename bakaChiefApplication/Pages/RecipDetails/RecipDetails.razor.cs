﻿using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using bakaChiefApplication.Store.Ingredients;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.RecipDetails;

public partial class RecipDetails
{
    [Inject] public IState<RecipsState> RecipsState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IState<IngredientsState> IngredientsState { get; set; }

    [Parameter] public string Id { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new RecipSearchByIdAction(Id));
    }

    private async Task RedirectToRecipsPage()
    {
        NavigationManager.NavigateTo(PagesUrl.RecipsPathUrl);
    }

    private async Task RedirectToRecipForm(string? RecipId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipFormUrl(FormMode.Update, RecipId));
        
        await Task.CompletedTask;
    }
}