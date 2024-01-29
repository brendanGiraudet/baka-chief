using bakaChiefApplication.Store.RecipTypes.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.RecipTypes;

public static class RecipTypesReducer
{
    #region RecipTypeSearchByName
    [ReducerMethod(typeof(RecipTypeSearchByNameAction))]
    public static RecipTypesState ReduceRecipTypeSearchByNameAction(RecipTypesState state) => new RecipTypesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipTypesState ReduceRecipTypeSearchByNameAction(RecipTypesState state, RecipTypeSearchByNameResultAction action) => new RecipTypesState(currentState: state, isLoading: false, recipTypes: action.SearchedRecipTypes);
    #endregion

    [ReducerMethod]
    public static RecipTypesState ReduceUpdateRecipTypeSearchTermAction(RecipTypesState state, UpdateRecipTypeSearchTermAction action) => new RecipTypesState(currentState: state, recipTypesearchTerm: action.RecipTypeSearchTerm);

    #region CreateRecipType
    [ReducerMethod(typeof(CreateRecipTypeAction))]
    public static RecipTypesState ReduceCreateRecipTypeAction(RecipTypesState state) => new RecipTypesState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static RecipTypesState ReduceCreateRecipTypeSucceedAction(RecipTypesState state, CreateRecipTypeSucceedAction action) => new RecipTypesState(currentState: state, isLoading: false, recipTypes: state.RecipTypes.Append(action.CreatedRecipType), recipType: new());
    #endregion

    #region RemoveRecipType
    [ReducerMethod(typeof(RemoveRecipTypeAction))]
    public static RecipTypesState ReduceRemoveRecipTypeAction(RecipTypesState state) => new RecipTypesState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static RecipTypesState ReduceRemoveRecipTypeSucceedAction(RecipTypesState state, RemoveRecipTypeSucceedAction action) => new RecipTypesState(currentState: state, isLoading: false, recipTypes: state.RecipTypes.Where(n => n.Id != action.RemovedRecipTypeId));
    #endregion

    [ReducerMethod]
    public static RecipTypesState ReduceRecipTypeSearchByIdAction(RecipTypesState state, RecipTypeSearchByIdAction action) => new RecipTypesState(currentState: state, recipType: state.RecipTypes.FirstOrDefault(n => n.Id == action.RecipTypeSearchTerm));

    #region UpdateRecipType
    [ReducerMethod(typeof(UpdateRecipTypeAction))]
    public static RecipTypesState ReduceUpdateRecipTypeAction(RecipTypesState state) => new RecipTypesState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static RecipTypesState ReduceUpdateRecipTypeSucceedAction(RecipTypesState state, UpdateRecipTypeSucceedAction action)
    {
        var RecipTypes = state.RecipTypes.Where(i => i.Id != action.UpdatedRecipType.Id);
        RecipTypes = RecipTypes.Append(action.UpdatedRecipType);

        return new RecipTypesState(currentState: state, isLoading: false, recipTypes: RecipTypes, recipType: new(), needToReload: false);
    }
    #endregion

    [ReducerMethod(typeof(RecipTypeCreationInitialisationAction))]
    public static RecipTypesState ReduceRecipTypeCreationInitialisationAction(RecipTypesState state) => new RecipTypesState(currentState: state, recipType: new());
}