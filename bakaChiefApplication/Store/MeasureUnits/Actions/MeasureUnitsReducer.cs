using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.MeasureUnits;

public static class MeasureUnitsReducer
{
    #region SearchByName
    [ReducerMethod]
    public static MeasureUnitsState ReduceSearchByNameAction(MeasureUnitsState state, SearchByNameAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static MeasureUnitsState ReduceSearchByNameResultAction(MeasureUnitsState state, SearchByNameResultAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    [ReducerMethod]
    public static MeasureUnitsState ReduceUpdateNameToSearchAction(MeasureUnitsState state, UpdateNameToSearchAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, nameToSearch: action.NameToSearch);

    #region Create
    [ReducerMethod]
    public static MeasureUnitsState ReduceCreateAction(MeasureUnitsState state, CreateAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static MeasureUnitsState ReduceCreateSucceedAction(MeasureUnitsState state, CreateSucceedAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static MeasureUnitsState ReduceDeleteAction(MeasureUnitsState state, DeleteAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static MeasureUnitsState ReduceDeleteSucceedAction(MeasureUnitsState state, DeleteAction<MeasureUnit> action) {
        var items = state.Items.Where(i => i.Id != action.ItemIdToRemove);

        return new MeasureUnitsState(currentState: state, isLoading: false, items: items);
    }
    #endregion

    #region SearchById
    [ReducerMethod]
    public static MeasureUnitsState ReduceSearchByIdAction(MeasureUnitsState state, SearchByIdAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static MeasureUnitsState ReduceSearchByIdResultAction(MeasureUnitsState state, SearchByIdResultAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static MeasureUnitsState ReduceUpdateAction(MeasureUnitsState state, UpdateAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static MeasureUnitsState ReduceUpdateSucceedAction(MeasureUnitsState state, UpdateSucceedAction<MeasureUnit> action)
    {
        var items = state.Items.Where(i => i.Id != action.UpdatedItem.Id);

        items = items.Append(action.UpdatedItem);

        return new MeasureUnitsState(currentState: state, isLoading: false, items: items, item: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static MeasureUnitsState ReduceCreationInitialisationAction(MeasureUnitsState state, CreationInitialisationAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, item: new());

    #region SearchByNameMore
    [ReducerMethod]
    public static MeasureUnitsState ReduceSearchByNameMoreAction(MeasureUnitsState state, SearchByNameMoreAction<MeasureUnit> action) => new MeasureUnitsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static MeasureUnitsState ReduceSearchByNameMoreResultAction(MeasureUnitsState state, SearchByNameMoreResultAction<MeasureUnit> action)
    {
        var items = state.Items.ToList();

        items.AddRange(action.SearchedItems);

        return new MeasureUnitsState(currentState: state, isLoading: false, items: items);
    }
    #endregion
}