using bakaChiefApplication.Store.Ingredient.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredient
{
    public static class IngredientReducer
    {
        [ReducerMethod(typeof(IngredientFetchDataAction))]
        public static IngredientState ReduceIngredientFetchDataAction(IngredientState state) => new IngredientState(isLoading: true, ingredients: null);
        
        [ReducerMethod]
        public static IngredientState ReduceIngredientFetchDataAction(IngredientState state , IngredientFetchDataResultAction action) => new IngredientState(isLoading: false, ingredients: action.Ingredients);
    }
}
