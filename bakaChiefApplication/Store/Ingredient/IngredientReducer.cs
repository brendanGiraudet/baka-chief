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

        [ReducerMethod(typeof(ShowIngredientFormAction))]
        public static IngredientState ReduceShowIngredientFormAction(IngredientState state) => new IngredientState(isLoading: false, ingredients: state.Ingredients, isIngredientFormHidden: false);
        
        [ReducerMethod(typeof(CloseIngredientFormAction))]
        public static IngredientState ReduceCloseIngredientFormAction(IngredientState state) => new IngredientState(isLoading: false, ingredients: state.Ingredients, isIngredientFormHidden: true);

        [ReducerMethod]
        public static IngredientState ReduceAddSelectedNutrimentAction(IngredientState state, AddSelectedNutrimentAction action) => new IngredientState(isLoading: false, ingredients: state.Ingredients, isIngredientFormHidden: false, selectedNutrimentTypes: state.SelectedNutrimentType.Append(action.NutrimentType));
        
        [ReducerMethod]
        public static IngredientState ReduceRemoveSelectedNutrimentAction(IngredientState state, RemoveSelectedNutrimentAction action) => new IngredientState(isLoading: false, ingredients: state.Ingredients, isIngredientFormHidden: false, selectedNutrimentTypes: state.SelectedNutrimentType.Where( s => s.Id != action.NutrimentType.Id));
    }
}
