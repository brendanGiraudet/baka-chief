using bakaChiefApplication.Services.RecipTypesService;
using bakaChiefApplication.Store.RecipTypes.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.RecipTypes;

public class RecipTypesEffect
{
    IRecipTypesService _RecipTypesService;

    public RecipTypesEffect(IRecipTypesService RecipTypesService)
    {
        _RecipTypesService = RecipTypesService;
    }

    [EffectMethod]
    public async Task HandleRecipTypeSearchByNameAction(RecipTypeSearchByNameAction action, IDispatcher dispatcher)
    {
        var RecipTypes = await _RecipTypesService.GetRecipTypesByNameAsync(action.RecipTypeSearchTerm);

        dispatcher.Dispatch(new RecipTypeSearchByNameResultAction(RecipTypes));
    }
    
    [EffectMethod]
    public async Task HandleCreateRecipTypeAction(CreateRecipTypeAction action, IDispatcher dispatcher)
    {
        var createRecipTypeResult = await _RecipTypesService.CreateRecipTypeAsync(action.RecipTypeToCreate);

        if(!createRecipTypeResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new CreateRecipTypeSucceedAction(createRecipTypeResult.Value!));
    }
    
    [EffectMethod]
    public async Task HandleRemoveRecipTypeAction(RemoveRecipTypeAction action, IDispatcher dispatcher)
    {
        var removedRecipTypeResult = await _RecipTypesService.RemoveRecipTypeAsync(action.RecipTypeIdToRemove);

        if(!removedRecipTypeResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new RemoveRecipTypeSucceedAction(removedRecipTypeResult.Value!));
    }
    
    [EffectMethod]
    public async Task HandleUpdateRecipTypeAction(UpdateRecipTypeAction action, IDispatcher dispatcher)
    {
        var updatedRecipTypeResult = await _RecipTypesService.UpdateRecipTypeAsync(action.RecipTypeToUpdate);

        if(!updatedRecipTypeResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new UpdateRecipTypeSucceedAction(updatedRecipTypeResult.Value!));
    }

    [EffectMethod]
    public async Task HandleAddMoreRecipTypesAction(AddMoreRecipTypesAction action, IDispatcher dispatcher)
    {
        var recipTypes = await _RecipTypesService.GetRecipTypesByNameAsync(action.RecipTypeSearchTerm, action.Take, action.Skip);

        dispatcher.Dispatch(new AddMoreRecipTypesResultAction(recipTypes));
    }
}