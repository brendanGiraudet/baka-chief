using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;
using System;

namespace bakaChiefApplication.Store.Ingredients
{
    public static class IngredientsReducer
    {
        #region IngredientsFetchData
        [ReducerMethod(typeof(IngredientsFetchDataAction))]
        public static IngredientsState ReduceIngredientFetchDataAction(IngredientsState state) => new IngredientsState(isLoading: true);

        [ReducerMethod]
        public static IngredientsState ReduceIngredientFetchDataResultAction(IngredientsState state, IngredientsFetchDataResultAction action) => new IngredientsState(isLoading: false, ingredients: action.Ingredients);
        #endregion IngredientFetchData

        #region IngredientForm
        [ReducerMethod(typeof(ShowIngredientFormAction))]
        public static IngredientsState ReduceShowIngredientFormAction(IngredientsState state) => new IngredientsState(ingredients: state.Ingredients, isIngredientFormHidden: false);

        [ReducerMethod(typeof(CloseIngredientFormAction))]
        public static IngredientsState ReduceCloseIngredientFormAction(IngredientsState state) => new IngredientsState(ingredients: state.Ingredients, isIngredientFormHidden: true);
        #endregion IngredientForm

        #region SelectedNutriment
        [ReducerMethod]
        public static IngredientsState ReduceAddSelectedNutrimentAction(IngredientsState state, AddSelectedNutrimentAction action)
        {
            state.Ingredient.Nutriments = state.Ingredient.Nutriments.Append(action.Nutriment);

            return new IngredientsState(ingredients: state.Ingredients, ingredient: state.Ingredient, isIngredientFormHidden: false);
        }

        [ReducerMethod]
        public static IngredientsState ReduceRemoveSelectedNutrimentAction(IngredientsState state, RemoveSelectedNutrimentAction action)
        {
            state.Ingredient.Nutriments = state.Ingredient.Nutriments.Where(n => n.Id != action.Nutriment.Id);

            return new IngredientsState(ingredients: state.Ingredients, ingredient: state.Ingredient, isIngredientFormHidden: false);
        }
        #endregion SelectedNutriment

        #region CreateIngredient
        [ReducerMethod]
        public static IngredientsState ReduceCreateIngredientAction(IngredientsState state, CreateIngredientAction action) => new IngredientsState(isLoading: true, ingredients: state.Ingredients);

        [ReducerMethod]
        public static IngredientsState ReduceCreateIngredientResultAction(IngredientsState state, CreateIngredientResultAction action) => new IngredientsState(isLoading: false, ingredients: state.Ingredients.Append(action.Ingredient));
        #endregion CreateIngredient

        #region DeleteIngredient
        [ReducerMethod(typeof(DeleteIngredientAction))]
        public static IngredientsState ReduceDeleteIngredientAction(IngredientsState state) => new IngredientsState(isLoading: true, ingredients: state.Ingredients);

        [ReducerMethod]
        public static IngredientsState ReduceDeleteIngredientResultAction(IngredientsState state, DeleteIngredientResultAction action) => new IngredientsState(isLoading: false, ingredients: state.Ingredients.Where(i => i.Id != action.IngredientId));

        #endregion DeleteIngredient

        #region IngredientFetchData
        [ReducerMethod]
        public static IngredientsState ReduceIngredientFetchDataAction(IngredientsState state, IngredientFetchDataAction action) => new IngredientsState(isLoading: true, ingredients: state.Ingredients, isIngredientFormHidden: false);

        [ReducerMethod]
        public static IngredientsState ReduceIngredientFetchDataResultAction(IngredientsState state, IngredientFetchDataResultAction action) => new IngredientsState(isLoading: false, ingredients: state.Ingredients, isIngredientFormHidden: false, ingredient: action.Ingredient);
        #endregion IngredientFetchData

        #region UpdateIngredient
        [ReducerMethod]
        public static IngredientsState ReduceUpdateIngredientAction(IngredientsState state, UpdateIngredientAction action) => new IngredientsState(isLoading: true, ingredients: state.Ingredients, isIngredientFormHidden: false, ingredient: action.Ingredient);

        [ReducerMethod]
        public static IngredientsState ReduceUpdateIngredientResultAction(IngredientsState state, UpdateIngredientResultAction action)
        {
            var ingredients = state.Ingredients.Where(i => i.Id != action.Ingredient.Id);
            ingredients = ingredients.Append(action.Ingredient);

            return new IngredientsState(isLoading: false, ingredients: state.Ingredients);
        }
        #endregion UpdateNutrimentAction
    }
}
