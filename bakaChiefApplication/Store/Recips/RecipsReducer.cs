using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Recips;

public static class RecipsReducer
{
    #region SearchByName
    [ReducerMethod]
    public static RecipsState ReduceSearchByNameAction(RecipsState state, SearchByNameAction<Recip> action) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceSearchByNameResultAction(RecipsState state, SearchByNameResultAction<Recip> action) => new RecipsState(currentState: state, isLoading: false, items: action.SearchedItems);
    #endregion

    [ReducerMethod]
    public static RecipsState ReduceUpdateNameToSearchAction(RecipsState state, UpdateNameToSearchAction<Recip> action) => new RecipsState(currentState: state, nameToSearch: action.NameToSearch);

    #region Create
    [ReducerMethod]
    public static RecipsState ReduceCreateAction(RecipsState state, CreateAction<Recip> action) => new RecipsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static RecipsState ReduceCreateSucceedAction(RecipsState state, CreateSucceedAction<Recip> action) => new RecipsState(currentState: state, isLoading: false, items: state.Items.Append(action.CreatedItem), item: new());
    #endregion

    #region Delete
    [ReducerMethod]
    public static RecipsState ReduceDeleteAction(RecipsState state, DeleteAction<Recip> action) => new RecipsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static RecipsState ReduceDeleteSucceedAction(RecipsState state, DeleteAction<Recip> action) {
        var items = state.Items.Where(i => i.Id != action.ItemIdToRemove);

        return new RecipsState(currentState: state, isLoading: false, items: items);
    }
    #endregion

    #region SearchById
    [ReducerMethod]
    public static RecipsState ReduceSearchByIdAction(RecipsState state, SearchByIdAction<Recip> action) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceSearchByIdResultAction(RecipsState state, SearchByIdResultAction<Recip> action) => new RecipsState(currentState: state, isLoading: false, item: action.Item);

    #endregion

    #region Update
    [ReducerMethod]
    public static RecipsState ReduceUpdateAction(RecipsState state, UpdateAction<Recip> action) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceUpdateSucceedAction(RecipsState state, UpdateSucceedAction<Recip> action)
    {
        var items = state.Items.Where(i => i.Id != action.UpdatedItem.Id);

        items = items.Append(action.UpdatedItem);

        return new RecipsState(currentState: state, isLoading: false, items: items, item: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static RecipsState ReduceCreationInitialisationAction(RecipsState state, CreationInitialisationAction<Recip> action) => new RecipsState(currentState: state, item: new());

    #region SearchByNameMore
    [ReducerMethod]
    public static RecipsState ReduceSearchByNameMoreAction(RecipsState state, SearchByNameMoreAction<Recip> action) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceSearchByNameMoreResultAction(RecipsState state, SearchByNameMoreResultAction<Recip> action)
    {
        var items = state.Items.ToList();

        items.AddRange(action.SearchedItems);

        return new RecipsState(currentState: state, isLoading: false, items: items);
    }
    #endregion

     [ReducerMethod]
    public static RecipsState ReduceAppendIngredientIntoRecipAction(RecipsState state, AppendIngredientIntoRecipAction action)
    {
        var recip = state.Item;
        recip.RecipIngredients = recip.RecipIngredients?.Append(action.SelectedIngredient).ToHashSet();

        return new RecipsState(currentState: state, item: recip);
    }

    [ReducerMethod]
    public static RecipsState ReduceRemoveIngredientIntoRecipAction(RecipsState state, RemoveIngredientIntoRecipAction action)
    {
        var Recip = state.Item;
        Recip.RecipIngredients = Recip.RecipIngredients.Where(n => n.IngredientId != action.RemovedIngredient.IngredientId).ToHashSet();

        return new RecipsState(currentState: state, item: Recip);
    }
}