using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Recips;

public static class RecipsReducer
{
    #region RecipSearchByName
    [ReducerMethod(typeof(RecipSearchByNameAction))]
    public static RecipsState ReduceRecipSearchByNameAction(RecipsState state) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceRecipSearchByNameResultAction(RecipsState state, RecipSearchByNameResultAction action) => new RecipsState(currentState: state, isLoading: false, recips: action.SearchedRecips);
    #endregion

    [ReducerMethod]
    public static RecipsState ReduceUpdateRecipSearchTermAction(RecipsState state, UpdateRecipSearchTermAction action) => new RecipsState(currentState: state, recipSearchTerm: action.RecipSearchTerm);

    #region CreateRecip
    [ReducerMethod(typeof(CreateRecipAction))]
    public static RecipsState ReduceCreateRecipAction(RecipsState state) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceCreateRecipSucceedAction(RecipsState state, CreateRecipSucceedAction action) => new RecipsState(currentState: state, isLoading: false, recips: state.Recips.Append(action.CreatedRecip), recip: new(), needToReload: false);
    #endregion

    #region RemoveRecip
    [ReducerMethod(typeof(RemoveRecipAction))]
    public static RecipsState ReduceRemoveRecipAction(RecipsState state) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceRemoveRecipSucceedAction(RecipsState state, RemoveRecipSucceedAction action) => new RecipsState(currentState: state, isLoading: false, recips: state.Recips.Where(n => n.Id != action.RemovedRecipId), recip: new(), needToReload: false);
    #endregion

    [ReducerMethod]
    public static RecipsState ReduceRecipSearchByIdAction(RecipsState state, RecipSearchByIdAction action) => new RecipsState(currentState: state, recip: state.Recips.FirstOrDefault(i => i.Id == action.RecipSearchTerm));

    #region UpdateRecip
    [ReducerMethod(typeof(UpdateRecipAction))]
    public static RecipsState ReduceUpdateRecipAction(RecipsState state) => new RecipsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipsState ReduceUpdateRecipSucceedAction(RecipsState state, UpdateRecipSucceedAction action)
    {
        var recips = state.Recips.Where(i => i.Id != action.UpdatedRecip.Id);
        recips = recips.Append(action.UpdatedRecip);

        return new RecipsState(currentState: state, isLoading: false, recips: recips, recip: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod]
    public static RecipsState ReduceAppendIngredientIntoRecipAction(RecipsState state, AppendIngredientIntoRecipAction action)
    {
        var recip = state.Recip;
        recip.Ingredients = recip.Ingredients.Append(action.SelectedIngredient).ToHashSet();

        return new RecipsState(currentState: state, recip: recip);
    }
    
    [ReducerMethod]
    public static RecipsState ReduceRemoveIngredientIntoRecipAction(RecipsState state, RemoveIngredientIntoRecipAction action)
    {
        var Recip = state.Recip;
        Recip.Ingredients = Recip.Ingredients.Where(n => n.Id != action.RemovedIngredient.Id).ToHashSet();

        return new RecipsState(currentState: state, recip: Recip);
    }

}