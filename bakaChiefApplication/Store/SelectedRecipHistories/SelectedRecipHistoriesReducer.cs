using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.SelectedRecipHistories;

public static class SelectedRecipHistoriesReducer
{
    #region SearchByName
    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSearchByNameAction(SelectedRecipHistoriesState state, SearchByNameAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSearchByNameResultAction(SelectedRecipHistoriesState state, SearchByNameResultAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceUpdateNameToSearchAction(SelectedRecipHistoriesState state, UpdateNameToSearchAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, nameToSearch: action.NameToSearch);

    #region Create
    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceCreateAction(SelectedRecipHistoriesState state, CreateAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceCreateSucceedAction(SelectedRecipHistoriesState state, CreateSucceedAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceDeleteAction(SelectedRecipHistoriesState state, DeleteAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceDeleteSucceedAction(SelectedRecipHistoriesState state, DeleteAction<SelectedRecipHistory> action)
    {
        var items = state.Items.Where(i => i.Id != action.ItemIdToRemove);

        return new SelectedRecipHistoriesState(currentState: state, isLoading: false, items: items);
    }
    #endregion

    #region SearchById
    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSearchByIdAction(SelectedRecipHistoriesState state, SearchByIdAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSearchByIdResultAction(SelectedRecipHistoriesState state, SearchByIdResultAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceUpdateAction(SelectedRecipHistoriesState state, UpdateAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceUpdateSucceedAction(SelectedRecipHistoriesState state, UpdateSucceedAction<SelectedRecipHistory> action)
    {
        var items = state.Items.Where(i => i.Id != action.UpdatedItem.Id);

        items = items.Append(action.UpdatedItem);

        return new SelectedRecipHistoriesState(currentState: state, isLoading: false, items: items, item: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceCreationInitialisationAction(SelectedRecipHistoriesState state, CreationInitialisationAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, item: new());

    #region SearchByNameMore
    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSearchByNameMoreAction(SelectedRecipHistoriesState state, SearchByNameMoreAction<SelectedRecipHistory> action) => new SelectedRecipHistoriesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSearchByNameMoreResultAction(SelectedRecipHistoriesState state, SearchByNameMoreResultAction<SelectedRecipHistory> action)
    {
        var items = state.Items.ToList();

        items.AddRange(action.SearchedItems);

        return new SelectedRecipHistoriesState(currentState: state, isLoading: false, items: items);
    }
    #endregion
}