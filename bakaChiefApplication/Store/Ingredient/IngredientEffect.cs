using bakaChiefApplication.Services.IngredientService;
using bakaChiefApplication.Store.Ingredient.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredient
{
    public class IngredientEffect
    {

        readonly IIngredientService _ingredientService;

        public IngredientEffect(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [EffectMethod(typeof(IngredientFetchDataAction))]
        public async Task HandleIngredientFetchDataAction(IDispatcher dispatcher)
        {
            var ingredients = await _ingredientService.GetAllIngredientAsync();

            dispatcher.Dispatch(new IngredientFetchDataResultAction(ingredients));
        }
    }
}
