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
    
    #region GenerateSelectedRecipHistory
    
    [ReducerMethod(typeof(GenerateSelectedRecipHistoryAction))]
    public static SelectedRecipHistoriesState ReduceGenerateSelectedRecipHistoryAction(SelectedRecipHistoriesState state) => new SelectedRecipHistoriesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceGenerateSelectedRecipHistoryResultAction(SelectedRecipHistoriesState state, GenerateSelectedRecipHistoryResultAction action) => new SelectedRecipHistoriesState(currentState: state, isLoading: false, selectedRecipHistories: state.SelectedRecipHistories.Prepend(action.GeneratedSelectedRecipHistory));
    
    #endregion

    [ReducerMethod]
    public static SelectedRecipHistoriesState ReduceSelectedRecipHistoryFetchAction(SelectedRecipHistoriesState state, SelectedRecipHistoryFetchAction action) => new SelectedRecipHistoriesState(currentState: state, selectedRecipHistory: state.SelectedRecipHistories.FirstOrDefault(s => s.Id == action.SelectedRecipHistoryId));
}