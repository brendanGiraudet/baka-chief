using bakaChiefApplication.Services.RecipsService;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Recips;

public class RecipsEffect
{
    IRecipsService _recipsService;

    public RecipsEffect(IRecipsService recipsService)
    {
        _recipsService = recipsService;
    }

    [EffectMethod]
    public async Task HandleRecipSearchByNameAction(RecipSearchByNameAction action, IDispatcher dispatcher)
    {
        var recips = await _recipsService.GetRecipsByNameAsync(action.RecipSearchTerm);

        dispatcher.Dispatch(new RecipSearchByNameResultAction(recips));
    }
    
    [EffectMethod]
    public async Task HandleCreateRecipAction(CreateRecipAction action, IDispatcher dispatcher)
    {
        var createRecipResult = await _recipsService.CreateRecipAsync(action.RecipToCreate);

        if(!createRecipResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new CreateRecipSucceedAction(createRecipResult.Value!));
    }
    
    [EffectMethod]
    public async Task HandleRemoveRecipAction(RemoveRecipAction action, IDispatcher dispatcher)
    {
        var removedRecipResult = await _recipsService.RemoveRecipAsync(action.RecipIdToRemove);

        if(!removedRecipResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new RemoveRecipSucceedAction(removedRecipResult.Value!));
    }

    [EffectMethod]
    public async Task HandleUpdateRecipAction(UpdateRecipAction action, IDispatcher dispatcher)
    {
        var updatedRecipResult = await _recipsService.UpdateRecipAsync(action.RecipToUpdate);

        if(!updatedRecipResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new UpdateRecipSucceedAction(updatedRecipResult.Value!));
    }
}