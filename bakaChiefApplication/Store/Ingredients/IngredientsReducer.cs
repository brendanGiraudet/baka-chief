using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Ingredients.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients;

public static class IngredientsReducer
{
    #region SearchByName
    [ReducerMethod]
    public static IngredientsState ReduceSearchByNameAction(IngredientsState state, SearchByNameAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceSearchByNameResultAction(IngredientsState state, SearchByNameResultAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    [ReducerMethod]
    public static IngredientsState ReduceUpdateNameToSearchAction(IngredientsState state, UpdateNameToSearchAction<Ingredient> action) => new IngredientsState(currentState: state, nameToSearch: action.NameToSearch);

    #region Create
    [ReducerMethod]
    public static IngredientsState ReduceCreateAction(IngredientsState state, CreateAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static IngredientsState ReduceCreateSucceedAction(IngredientsState state, CreateSucceedAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static IngredientsState ReduceDeleteAction(IngredientsState state, DeleteAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static IngredientsState ReduceDeleteSucceedAction(IngredientsState state, DeleteAction<Ingredient> action) {
        var items = state.Items.Where(i => i.Id != action.ItemIdToRemove);

        return new IngredientsState(currentState: state, isLoading: false, items: items);
    }
    #endregion

    #region SearchById
    [ReducerMethod]
    public static IngredientsState ReduceSearchByIdAction(IngredientsState state, SearchByIdAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceSearchByIdResultAction(IngredientsState state, SearchByIdResultAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static IngredientsState ReduceUpdateAction(IngredientsState state, UpdateAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceUpdateSucceedAction(IngredientsState state, UpdateSucceedAction<Ingredient> action)
    {
        var items = state.Items.Where(i => i.Id != action.UpdatedItem.Id);

        items = items.Append(action.UpdatedItem);

        return new IngredientsState(currentState: state, isLoading: false, items: items, item: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static IngredientsState ReduceCreationInitialisationAction(IngredientsState state, CreationInitialisationAction<Ingredient> action) => new IngredientsState(currentState: state, item: new());

    #region SearchByNameMore
    [ReducerMethod]
    public static IngredientsState ReduceSearchByNameMoreAction(IngredientsState state, SearchByNameMoreAction<Ingredient> action) => new IngredientsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static IngredientsState ReduceSearchByNameMoreResultAction(IngredientsState state, SearchByNameMoreResultAction<Ingredient> action)
    {
        var items = state.Items.ToList();

        items.AddRange(action.SearchedItems);

        return new IngredientsState(currentState: state, isLoading: false, items: items);
    }
    #endregion

     [ReducerMethod]
    public static IngredientsState ReduceAppendNutrimentIntoIngredientAction(IngredientsState state, AppendNutrimentIntoIngredientAction action)
    {
        var ingredient = state.Item;
        ingredient.IngredientNutriments = ingredient.IngredientNutriments?.Append(action.SelectedNutriment).ToHashSet();

        return new IngredientsState(currentState: state, item: ingredient);
    }

    [ReducerMethod]
    public static IngredientsState ReduceRemoveNutrimentIntoIngredientAction(IngredientsState state, RemoveNutrimentIntoIngredientAction action)
    {
        var ingredient = state.Item;
        ingredient.IngredientNutriments = ingredient.IngredientNutriments.Where(n => n.NutrimentId != action.RemovedNutriment.NutrimentId).ToHashSet();

        return new IngredientsState(currentState: state, item: ingredient);
    }
}