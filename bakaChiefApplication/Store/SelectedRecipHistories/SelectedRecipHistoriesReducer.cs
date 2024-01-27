using bakaChiefApplication.Store.SelectedRecipHistories.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.SelectedRecipHistories;

public static class SelectedRecipHistoriesReducer
{
    #region SelectedRecipHistories
    [ReducerMethod(typeof(SelectedRecipHistoriesFetchAction))]
    public static SelectedRecipHistoriesState ReduceSelectedRecipHistoriesFetchAction(SelectedRecipHistoriesState state) => new SelectedRecipHistoriesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSelectedRecipHistoriesFetchAction(SelectedRecipHistoriesState state, SelectedRecipHistoriesFetchResultAction action) => new SelectedRecipHistoriesState(currentState: state, isLoading: false, selectedRecipHistories: action.SelectedRecipHistories);

    #endregion
}