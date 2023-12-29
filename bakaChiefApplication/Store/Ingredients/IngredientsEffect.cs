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
        var ingredients = await _ingredientsService.GetIngredientsByNameAsync(action.IngredientSearchTerm);

        dispatcher.Dispatch(new IngredientSearchByNameResultAction(ingredients));
    }
    
    [EffectMethod]
    public async Task HandleCreateIngredientAction(CreateIngredientAction action, IDispatcher dispatcher)
    {
        var createIngredientResult = await _ingredientsService.CreateIngredientAsync(action.IngredientToCreate);

        if(!createIngredientResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new CreateIngredientSucceedAction(createIngredientResult.Value!));
    }
    
    [EffectMethod]
    public async Task HandleRemoveIngredientAction(RemoveIngredientAction action, IDispatcher dispatcher)
    {
        var removedIngredientResult = await _ingredientsService.RemoveIngredientAsync(action.IngredientIdToRemove);

        if(!removedIngredientResult.IsSuccess())
        {
            // TODO show error message
        }

        dispatcher.Dispatch(new RemoveIngredientSucceedAction(removedIngredientResult.Value!));
    }
}