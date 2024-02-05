﻿using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.BaseStore;

public static class BaseReducer<T>
{
    #region SearchByName
    [ReducerMethod]
    public static BaseState<T> ReduceSearchByNameAction(BaseState<T> state, SearchByNameAction<T> action) => new BaseState<T>(currentState: state, isLoading: true);

    [ReducerMethod]
    public static BaseState<T> ReduceNutrimentSearchByNameAction(BaseState<T> state, SearchByNameResultAction<T> action) => new BaseState<T>(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    // [ReducerMethod]
    // public static BaseState<T> ReduceUpdateNutrimentSearchTermAction(BaseState<T> state, UpdateNutrimentSearchTermAction action) => new BaseState<T>(currentState: state, nutrimentSearchTerm: action.NutrimentSearchTerm);

    #region Create
    [ReducerMethod]
    public static BaseState<T> ReduceCreateAction(BaseState<T> state, CreateAction<T> action) => new BaseState<T>(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static BaseState<T> ReduceCreateSucceedAction(BaseState<T> state, CreateSucceedAction<T> action) => new BaseState<T>(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static BaseState<T> ReduceDeleteAction(BaseState<T> state, DeleteAction<T> action) => new BaseState<T>(currentState: state, isLoading: true, needToReload: false);

    // [ReducerMethod]
    // public static BaseState<T> ReduceDeleteSucceedAction(BaseState<T> state, DeleteAction<T> action) => new BaseState<T>(currentState: state, isLoading: false, items: state.Items.Where(n => n.Id != action.ItemIdToRemove));
    #endregion

    #region SearchById
    [ReducerMethod]
    public static BaseState<T> ReduceSearchByIdAction(BaseState<T> state, SearchByIdAction<T> action) => new BaseState<T>(currentState: state, isLoading: true);

    [ReducerMethod]
    public static BaseState<T> ReduceSearchByIdResultAction(BaseState<T> state, SearchByIdResultAction<T> action) => new BaseState<T>(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static BaseState<T> ReduceUpdateAction(BaseState<T> state, UpdateAction<T> action) => new BaseState<T>(currentState: state, isLoading: true);

    // [ReducerMethod]
    // public static BaseState<T> ReduceUpdateSucceedAction(BaseState<T> state, UpdateSucceedAction<T> action)
    // {
    //     var nutriments = state.Items.Where(i => i.Id != action.UpdatedNutriment.Id);
    //     nutriments = nutriments.Append(action.UpdatedNutriment);

    //     return new BaseState<T>(currentState: state, isLoading: false, items: nutriments, nutriment: new(), needToReload: false);
    // }
    #endregion

    [ReducerMethod]
    public static BaseState<T> ReduceCreationInitialisationAction(BaseState<T> state, CreationInitialisationAction<T> action) => new BaseState<T>(currentState: state, item: new());

    // #region AddMoreNutriments
    // [ReducerMethod(typeof(AddMoreNutrimentsAction))]
    // public static BaseState<T> ReduceAddMoreNutrimentsAction(BaseState<T> state) => new BaseState<T>(currentState: state, isLoading: true);

    // [ReducerMethod]
    // public static BaseState<T> ReduceAddMoreNutrimentsResultAction(BaseState<T> state, AddMoreNutrimentsResultAction action)
    // {
    //     var nutriments = state.Nutriments.ToList();

    //     nutriments.AddRange(action.SearchedNutriments);

    //     return new BaseState<T>(currentState: state, isLoading: false, items: nutriments);
    // }
    // #endregion
}