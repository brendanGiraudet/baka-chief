using bakaChiefApplication.Store.Ingredient.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredient
{
    public static class IngredientReducer
    {
        [ReducerMethod(typeof(IngredientFetchDataAction))]
        public static IngredientState ReduceIngredientFetchDataAction(IngredientState state) => new IngredientState(isLoading: true);
        
        [ReducerMethod]
        public static IngredientState ReduceIngredientFetchDataResultAction(IngredientState state , IngredientFetchDataResultAction action) => new IngredientState(isLoading: false, ingredients: action.Ingredients);

        [ReducerMethod(typeof(ShowIngredientFormAction))]
        public static IngredientState ReduceShowIngredientFormAction(IngredientState state) => new IngredientState(ingredients: state.Ingredients, isIngredientFormHidden: false);
        
        [ReducerMethod(typeof(CloseIngredientFormAction))]
        public static IngredientState ReduceCloseIngredientFormAction(IngredientState state) => new IngredientState(ingredients: state.Ingredients, isIngredientFormHidden: true);

        [ReducerMethod]
        public static IngredientState ReduceAddSelectedNutrimentAction(IngredientState state, AddSelectedNutrimentAction action) => new IngredientState(ingredients: state.Ingredients, selectedNutrimentTypes: state.SelectedNutrimentType.Append(action.NutrimentType), isIngredientFormHidden: false);
        
        [ReducerMethod]
        public static IngredientState ReduceRemoveSelectedNutrimentAction(IngredientState state, RemoveSelectedNutrimentAction action) => new IngredientState(ingredients: state.Ingredients, selectedNutrimentTypes: state.SelectedNutrimentType.Where( s => s.Id != action.NutrimentType.Id), isIngredientFormHidden: false);

        [ReducerMethod]
        public static IngredientState ReduceAddIngredientAction(IngredientState state, AddIngredientAction action) => new IngredientState(isLoading: true, ingredients: state.Ingredients);
        
        [ReducerMethod]
        public static IngredientState ReduceAddIngredientResultAction(IngredientState state, AddIngredientResultAction action) => new IngredientState(isLoading: false, ingredients: state.Ingredients.Append(action.Ingredient));
        
        [ReducerMethod(typeof(DeleteIngredientAction))]
        public static IngredientState ReduceDeleteIngredientAction(IngredientState state) => new IngredientState(isLoading: true, ingredients: state.Ingredients);
        
        [ReducerMethod]
        public static IngredientState ReduceDeleteIngredientResultAction(IngredientState state, DeleteIngredientResultAction action) => new IngredientState(isLoading: false, ingredients: state.Ingredients.Where(i => i.Id != action.IngredientId));
    }
}
