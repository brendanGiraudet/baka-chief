using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments;

public static class NutrimentsReducer
{
    #region NutrimentSearchByName
    [ReducerMethod(typeof(NutrimentSearchByNameAction))]
    public static NutrimentsState ReduceNutrimentSearchByNameAction(NutrimentsState state) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceNutrimentSearchByNameAction(NutrimentsState state, NutrimentSearchByNameResultAction action) => new NutrimentsState(currentState: state, isLoading: false, nutriments: action.SearchedNutriments);
    #endregion

    [ReducerMethod]
    public static NutrimentsState ReduceUpdateNutrimentSearchTermAction(NutrimentsState state, UpdateNutrimentSearchTermAction action) => new NutrimentsState(currentState: state, nutrimentSearchTerm: action.NutrimentSearchTerm);

    #region CreateNutriment
    [ReducerMethod(typeof(CreateNutrimentAction))]
    public static NutrimentsState ReduceCreateNutrimentAction(NutrimentsState state) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceCreateNutrimentSucceedAction(NutrimentsState state, CreateNutrimentSucceedAction action) => new NutrimentsState(currentState: state, isLoading: false, nutriments: state.Nutriments.Append(action.CreatedNutriment), nutriment: new());
    #endregion
}