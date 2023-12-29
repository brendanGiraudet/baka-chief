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
    public static IngredientsState ReduceCreateIngredientSucceedAction(IngredientsState state, CreateIngredientSucceedAction action) => new IngredientsState(currentState: state, isLoading: false, ingredients: state.Ingredients.Append(action.CreatedIngredient), ingredient: new());
    #endregion
    
    #region RemoveIngredient
    [ReducerMethod(typeof(RemoveIngredientAction))]
    public static IngredientsState ReduceRemoveIngredientAction(IngredientsState state) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceRemoveIngredientSucceedAction(IngredientsState state, RemoveIngredientSucceedAction action) => new IngredientsState(currentState: state, isLoading: false, ingredients: state.Ingredients.Where(n => n.Id != action.RemovedIngredientId));
    #endregion
}