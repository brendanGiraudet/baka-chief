using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients
{
    public static class IngredientsReducer
    {
        [ReducerMethod(typeof(IngredientFetchDataAction))]
        public static IngredientsState ReduceIngredientFetchDataAction(IngredientsState state) => new IngredientsState(isLoading: true);
        
        [ReducerMethod]
        public static IngredientsState ReduceIngredientFetchDataResultAction(IngredientsState state , IngredientFetchDataResultAction action) => new IngredientsState(isLoading: false, ingredients: action.Ingredients);

        [ReducerMethod(typeof(ShowIngredientFormAction))]
        public static IngredientsState ReduceShowIngredientFormAction(IngredientsState state) => new IngredientsState(ingredients: state.Ingredients, isIngredientFormHidden: false);
        
        [ReducerMethod(typeof(CloseIngredientFormAction))]
        public static IngredientsState ReduceCloseIngredientFormAction(IngredientsState state) => new IngredientsState(ingredients: state.Ingredients, isIngredientFormHidden: true);

        [ReducerMethod]
        public static IngredientsState ReduceAddSelectedNutrimentAction(IngredientsState state, AddSelectedNutrimentAction action) => new IngredientsState(ingredients: state.Ingredients, selectedNutrimentTypes: state.SelectedNutrimentType.Append(action.NutrimentType), isIngredientFormHidden: false);
        
        [ReducerMethod]
        public static IngredientsState ReduceRemoveSelectedNutrimentAction(IngredientsState state, RemoveSelectedNutrimentAction action) => new IngredientsState(ingredients: state.Ingredients, selectedNutrimentTypes: state.SelectedNutrimentType.Where( s => s.Id != action.NutrimentType.Id), isIngredientFormHidden: false);

        [ReducerMethod]
        public static IngredientsState ReduceAddIngredientAction(IngredientsState state, AddIngredientAction action) => new IngredientsState(isLoading: true, ingredients: state.Ingredients);
        
        [ReducerMethod]
        public static IngredientsState ReduceAddIngredientResultAction(IngredientsState state, AddIngredientResultAction action) => new IngredientsState(isLoading: false, ingredients: state.Ingredients.Append(action.Ingredient));
        
        [ReducerMethod(typeof(DeleteIngredientAction))]
        public static IngredientsState ReduceDeleteIngredientAction(IngredientsState state) => new IngredientsState(isLoading: true, ingredients: state.Ingredients);
        
        [ReducerMethod]
        public static IngredientsState ReduceDeleteIngredientResultAction(IngredientsState state, DeleteIngredientResultAction action) => new IngredientsState(isLoading: false, ingredients: state.Ingredients.Where(i => i.Id != action.IngredientId));
    }
}
