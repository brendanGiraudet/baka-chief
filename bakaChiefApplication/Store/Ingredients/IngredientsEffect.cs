using bakaChiefApplication.Services.IngredientsService;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients;

public class IngredientsEffect
{
    IIngredientsService _ingredientsService;

    public IngredientsEffect(IIngredientsService ingredientsService)
    {
        _ingredientsService = ingredientsService;
    }

    [EffectMethod]
    public async Task HandleIngredientSearchByNameAction(IngredientSearchByNameAction action, IDispatcher dispatcher)
    {
        var ingredients = await _ingredientsService.GetIngredientsByNameAsync(action.IngredientSearchTerm, action.Take);

        dispatcher.Dispatch(new IngredientSearchByNameResultAction(ingredients));
    }

    [EffectMethod]
    public async Task HandleCreateIngredientAction(CreateIngredientAction action, IDispatcher dispatcher)
    {
        var createIngredientResult = await _ingredientsService.CreateIngredientAsync(action.IngredientToCreate);

        if (!createIngredientResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new CreateIngredientSucceedAction(createIngredientResult.Value!));
    }

    [EffectMethod]
    public async Task HandleRemoveIngredientAction(RemoveIngredientAction action, IDispatcher dispatcher)
    {
        var removedIngredientResult = await _ingredientsService.RemoveIngredientAsync(action.IngredientIdToRemove);

        if (!removedIngredientResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new RemoveIngredientSucceedAction(removedIngredientResult.Value!));
    }

    [EffectMethod]
    public async Task HandleUpdateIngredientAction(UpdateIngredientAction action, IDispatcher dispatcher)
    {
        var updatedIngredientResult = await _ingredientsService.UpdateIngredientAsync(action.IngredientToUpdate);

        if (!updatedIngredientResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new UpdateIngredientSucceedAction(updatedIngredientResult.Value!));
    }

    [EffectMethod]
    public async Task HandleAddMoreIngredientsAction(AddMoreIngredientsAction action, IDispatcher dispatcher)
    {
        var ingredients = await _ingredientsService.GetIngredientsByNameAsync(action.IngredientsearchTerm, action.Take, action.Skip);

        dispatcher.Dispatch(new AddMoreIngredientsResultAction(ingredients));
    }
}