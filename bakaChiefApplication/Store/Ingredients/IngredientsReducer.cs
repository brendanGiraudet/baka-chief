using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients;

public static class IngredientsReducer
{
    #region IngredientSearchByName
    [ReducerMethod(typeof(IngredientSearchByNameAction))]
    public static IngredientsState ReduceIngredientSearchByNameAction(IngredientsState state) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceIngredientSearchByNameResultAction(IngredientsState state, IngredientSearchByNameResultAction action) => new IngredientsState(currentState: state, isLoading: false, ingredients: action.SearchedIngredients);
    #endregion

    [ReducerMethod]
    public static IngredientsState ReduceUpdateIngredientSearchTermAction(IngredientsState state, UpdateIngredientSearchTermAction action) => new IngredientsState(currentState: state, ingredientSearchTerm: action.IngredientSearchTerm);

    #region CreateIngredient
    [ReducerMethod(typeof(CreateIngredientAction))]
    public static IngredientsState ReduceCreateIngredientAction(IngredientsState state) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceCreateIngredientSucceedAction(IngredientsState state, CreateIngredientSucceedAction action) => new IngredientsState(currentState: state, isLoading: false, ingredients: state.Ingredients.Append(action.CreatedIngredient), ingredient: new(), needToReload: false);
    #endregion

    #region RemoveIngredient
    [ReducerMethod(typeof(RemoveIngredientAction))]
    public static IngredientsState ReduceRemoveIngredientAction(IngredientsState state) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceRemoveIngredientSucceedAction(IngredientsState state, RemoveIngredientSucceedAction action) => new IngredientsState(currentState: state, isLoading: false, ingredients: state.Ingredients.Where(n => n.Id != action.RemovedIngredientId), ingredient: new(), needToReload: false);
    #endregion

    [ReducerMethod]
    public static IngredientsState ReduceIngredientSearchByIdAction(IngredientsState state, IngredientSearchByIdAction action) => new IngredientsState(currentState: state, ingredient: state.Ingredients.FirstOrDefault(i => i.Id == action.IngredientSearchTerm));

    #region UpdateIngredient
    [ReducerMethod(typeof(UpdateIngredientAction))]
    public static IngredientsState ReduceUpdateIngredientAction(IngredientsState state) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceUpdateIngredientSucceedAction(IngredientsState state, UpdateIngredientSucceedAction action)
    {
        var ingredients = state.Ingredients.Where(i => i.Id != action.UpdatedIngredient.Id);
        ingredients = ingredients.Append(action.UpdatedIngredient);

        return new IngredientsState(currentState: state, isLoading: false, ingredients: ingredients, ingredient: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static IngredientsState ReduceAppendNutrimentIntoIngredientAction(IngredientsState state, AppendNutrimentIntoIngredientAction action)
    {
        var ingredient = state.Ingredient;
        ingredient.IngredientNutriments = ingredient.IngredientNutriments?.Append(action.SelectedNutriment).ToHashSet();

        return new IngredientsState(currentState: state, ingredient: ingredient);
    }

    [ReducerMethod]
    public static IngredientsState ReduceRemoveNutrimentIntoIngredientAction(IngredientsState state, RemoveNutrimentIntoIngredientAction action)
    {
        var ingredient = state.Ingredient;
        ingredient.IngredientNutriments = ingredient.IngredientNutriments.Where(n => n.NutrimentId != action.RemovedNutriment.NutrimentId).ToHashSet();

        return new IngredientsState(currentState: state, ingredient: ingredient);
    }

    [ReducerMethod(typeof(IngredientCreationInitialisationAction))]
    public static IngredientsState ReduceIngredientCreationInitialisationAction(IngredientsState state) => new IngredientsState(currentState: state, ingredient: new());

}