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
    public static NutrimentsState ReduceCreateNutrimentAction(NutrimentsState state) => new NutrimentsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static NutrimentsState ReduceCreateNutrimentSucceedAction(NutrimentsState state, CreateNutrimentSucceedAction action) => new NutrimentsState(currentState: state, isLoading: false, nutriments: state.Nutriments.Append(action.CreatedNutriment), nutriment: new());
    #endregion
    
    #region RemoveNutriment
    [ReducerMethod(typeof(RemoveNutrimentAction))]
    public static NutrimentsState ReduceRemoveNutrimentAction(NutrimentsState state) => new NutrimentsState(currentState: state, isLoading: true, needToReload: false);

    [ReducerMethod]
    public static NutrimentsState ReduceRemoveNutrimentSucceedAction(NutrimentsState state, RemoveNutrimentSucceedAction action) => new NutrimentsState(currentState: state, isLoading: false, nutriments: state.Nutriments.Where(n => n.Id != action.RemovedNutrimentId));
    #endregion

    [ReducerMethod]
    public static NutrimentsState ReduceNutrimentSearchByIdAction(NutrimentsState state, NutrimentSearchByIdAction action) => new NutrimentsState(currentState: state, nutriment: state.Nutriments.FirstOrDefault(n => n.Id == action.NutrimentSearchTerm));

    #region UpdateNutriment
    [ReducerMethod(typeof(UpdateNutrimentAction))]
    public static NutrimentsState ReduceUpdateNutrimentAction(NutrimentsState state) => new NutrimentsState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static NutrimentsState ReduceUpdateNutrimentSucceedAction(NutrimentsState state, UpdateNutrimentSucceedAction action)
    {
        var nutriments = state.Nutriments.Where(i => i.Id != action.UpdatedNutriment.Id);
        nutriments = nutriments.Append(action.UpdatedNutriment);

        return new NutrimentsState(currentState: state, isLoading: false, nutriments: nutriments, nutriment: new(), needToReload: false);
    }
    #endregion
}