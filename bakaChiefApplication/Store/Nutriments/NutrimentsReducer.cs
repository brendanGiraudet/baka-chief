using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments;

public static class NutrimentsReducer
{
    #region SearchByName
    [ReducerMethod]
    public static NutrimentsState ReduceSearchByNameAction(NutrimentsState state, SearchByNameAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceSearchByNameResultAction(NutrimentsState state, SearchByNameResultAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    [ReducerMethod]
    public static NutrimentsState ReduceUpdateNameToSearchAction(NutrimentsState state, UpdateNameToSearchAction<Nutriment> action) => new NutrimentsState(currentState: state, nameToSearch: action.NameToSearch);

    #region Create
    [ReducerMethod]
    public static NutrimentsState ReduceCreateAction(NutrimentsState state, CreateAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static NutrimentsState ReduceCreateSucceedAction(NutrimentsState state, CreateSucceedAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static NutrimentsState ReduceDeleteAction(NutrimentsState state, DeleteAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static NutrimentsState ReduceDeleteSucceedAction(NutrimentsState state, DeleteAction<Nutriment> action) {
        var items = state.Items.Where(i => i.Id != action.ItemIdToRemove);

        return new NutrimentsState(currentState: state, isLoading: false, items: items);
    }
    #endregion

    #region SearchById
    [ReducerMethod]
    public static NutrimentsState ReduceSearchByIdAction(NutrimentsState state, SearchByIdAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceSearchByIdResultAction(NutrimentsState state, SearchByIdResultAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static NutrimentsState ReduceUpdateAction(NutrimentsState state, UpdateAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceUpdateSucceedAction(NutrimentsState state, UpdateSucceedAction<Nutriment> action)
    {
        var items = state.Items.Where(i => i.Id != action.UpdatedItem.Id);

        items = items.Append(action.UpdatedItem);

        return new NutrimentsState(currentState: state, isLoading: false, items: items, item: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static NutrimentsState ReduceCreationInitialisationAction(NutrimentsState state, CreationInitialisationAction<Nutriment> action) => new NutrimentsState(currentState: state, item: new());

    #region SearchByNameMore
    [ReducerMethod]
    public static NutrimentsState ReduceSearchByNameMoreAction(NutrimentsState state, SearchByNameMoreAction<Nutriment> action) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceSearchByNameMoreResultAction(NutrimentsState state, SearchByNameMoreResultAction<Nutriment> action)
    {
        var items = state.Items.ToList();

        items.AddRange(action.SearchedItems);

        return new NutrimentsState(currentState: state, isLoading: false, items: items);
    }
    #endregion
}