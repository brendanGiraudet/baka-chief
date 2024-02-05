﻿using bakaChiefApplication.Services.SelectedRecipHistoriesService;
using bakaChiefApplication.Store.SelectedRecipHistories.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.SelectedRecipHistories;

public class SelectedRecipHistoriesEffect
{
    private ISelectedRecipHistoriesService _selectedRecipHistoriesService;

    public SelectedRecipHistoriesEffect(ISelectedRecipHistoriesService selectedRecipHistoriesService)
    {
        _selectedRecipHistoriesService = selectedRecipHistoriesService;
    }

    [EffectMethod]
    public async Task HandleSelectedRecipHistoriesFetchAction(SelectedRecipHistoriesFetchAction action, IDispatcher dispatcher)
    {
        var selectedRecipHistoriesResponse = await _selectedRecipHistoriesService.GetSelectedRecipHistoriesAsync();

        if (!selectedRecipHistoriesResponse.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new SelectedRecipHistoriesFetchResultAction(selectedRecipHistoriesResponse.Value));
    }
    
    [EffectMethod]
    public async Task HandleGenerateSelectedRecipHistoryAction(GenerateSelectedRecipHistoryAction action, IDispatcher dispatcher)
    {
        var selectedRecipHistoryResponse = await _selectedRecipHistoriesService.GenerateSelectedRecipHistoriesAsync();

        if (!selectedRecipHistoryResponse.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new GenerateSelectedRecipHistoryResultAction(selectedRecipHistoryResponse.Value));
    }

    [EffectMethod]
    public async Task HandleRecipSearchByIdAction(SelectedRecipHistorySearchByIdAction action, IDispatcher dispatcher)
    {
        var getRecipsByIdResult = await _selectedRecipHistoriesService.GetSelectedRecipHistoryByIdAsync(action.SelectedRecipHistoryId);

        dispatcher.Dispatch(new SelectedRecipHistorySearchByIdResultAction(getRecipsByIdResult.Value));
    }

    [EffectMethod]
    public async Task HandleRemoveSelectedRecipHistoryAction(RemoveSelectedRecipHistoryAction action, IDispatcher dispatcher)
    {
        var removedSelectedRecipHistoryResult = await _selectedRecipHistoriesService.RemoveSelectedRecipHistoryAsync(action.SelectedRecipHistoryIdToRemove);

        if(!removedSelectedRecipHistoryResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new RemoveSelectedRecipHistorySucceedAction(removedSelectedRecipHistoryResult.Value!));
    }
}