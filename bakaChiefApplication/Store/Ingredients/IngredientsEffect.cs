using bakaChiefApplication.Services.IngredientsService;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients

{
    public class IngredientsEffect
    {

        readonly IIngredientsService _ingredientService;

        public IngredientsEffect(IIngredientsService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [EffectMethod(typeof(IngredientsFetchDataAction))]
        public async Task HandleIngredientFetchDataAction(IDispatcher dispatcher)
        {
            var ingredients = await _ingredientService.GetAllIngredientAsync();

            dispatcher.Dispatch(new IngredientsFetchDataResultAction(ingredients));
        }
        
        [EffectMethod]
        public async Task HandleAddIngredientAction(CreateIngredientAction action, IDispatcher dispatcher)
        {
            var ingredient = await _ingredientService.CreateIngredientAsync(action.Ingredient);

            dispatcher.Dispatch(new CreateIngredientResultAction(ingredient));
        }
        
        [EffectMethod]
        public async Task HandleDeleteIngredientAction(DeleteIngredientAction action, IDispatcher dispatcher)
        {
            await _ingredientService.DeleteIngredientAsync(action.IngredientId);

            dispatcher.Dispatch(new DeleteIngredientResultAction(action.IngredientId));
        }
        
        [EffectMethod]
        public async Task HandleIngredientFetchDataAction(IngredientFetchDataAction action, IDispatcher dispatcher)
        {
            var ingredient = await _ingredientService.GetIngredientByIdAsync(action.IngredientId);

            dispatcher.Dispatch(new IngredientFetchDataResultAction(ingredient));
        }
        
        [EffectMethod]
        public async Task HandleUpdateIngredientAction(UpdateIngredientAction action, IDispatcher dispatcher)
        {
            await _ingredientService.UpdateIngredientAsync(action.Ingredient);

            dispatcher.Dispatch(new UpdateIngredientResultAction(action.Ingredient));
        }
    }
}
