using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.RecipTypes;

public static class RecipTypesReducer
{
    #region SearchByName
    [ReducerMethod]
    public static RecipTypesState ReduceSearchByNameAction(RecipTypesState state, SearchByNameAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipTypesState ReduceSearchByNameResultAction(RecipTypesState state, SearchByNameResultAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    [ReducerMethod]
    public static RecipTypesState ReduceUpdateNameToSearchAction(RecipTypesState state, UpdateNameToSearchAction<RecipType> action) => new RecipTypesState(currentState: state, nameToSearch: action.NameToSearch);

    #region Create
    [ReducerMethod]
    public static RecipTypesState ReduceCreateAction(RecipTypesState state, CreateAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static RecipTypesState ReduceCreateSucceedAction(RecipTypesState state, CreateSucceedAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static RecipTypesState ReduceDeleteAction(RecipTypesState state, DeleteAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static RecipTypesState ReduceDeleteSucceedAction(RecipTypesState state, DeleteAction<RecipType> action) {
        var items = state.Items.Where(i => i.Id != action.ItemIdToRemove);

        return new RecipTypesState(currentState: state, isLoading: false, items: items);
    }
    #endregion

    #region SearchById
    [ReducerMethod]
    public static RecipTypesState ReduceSearchByIdAction(RecipTypesState state, SearchByIdAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipTypesState ReduceSearchByIdResultAction(RecipTypesState state, SearchByIdResultAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static RecipTypesState ReduceUpdateAction(RecipTypesState state, UpdateAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipTypesState ReduceUpdateSucceedAction(RecipTypesState state, UpdateSucceedAction<RecipType> action)
    {
        var items = state.Items.Where(i => i.Id != action.UpdatedItem.Id);

        items = items.Append(action.UpdatedItem);

        return new RecipTypesState(currentState: state, isLoading: false, items: items, item: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static RecipTypesState ReduceCreationInitialisationAction(RecipTypesState state, CreationInitialisationAction<RecipType> action) => new RecipTypesState(currentState: state, item: new());

    #region SearchByNameMore
    [ReducerMethod]
    public static RecipTypesState ReduceSearchByNameMoreAction(RecipTypesState state, SearchByNameMoreAction<RecipType> action) => new RecipTypesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipTypesState ReduceSearchByNameMoreResultAction(RecipTypesState state, SearchByNameMoreResultAction<RecipType> action)
    {
        var items = state.Items.ToList();

        items.AddRange(action.SearchedItems);

        return new RecipTypesState(currentState: state, isLoading: false, items: items);
    }
    #endregion
}