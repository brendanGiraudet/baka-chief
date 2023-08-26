using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    public static class NutrimentTypeReducer
    {
        [ReducerMethod(typeof(NutrimentTypeFetchhDataAction))]
        public static NutrimentTypeState ReduceNutrimentTypeFetchhDataAction(NutrimentTypeState state) => new NutrimentTypeState(isLoading: true, nutrimentTypes: null);

        [ReducerMethod]
        public static NutrimentTypeState ReduceNutrimentTypeFetchDataResultAction(NutrimentTypeState state, NutrimentTypeFetchDataResultAction action) => new NutrimentTypeState(isLoading: false, nutrimentTypes: action.NutrimentTypes);
    }
}
