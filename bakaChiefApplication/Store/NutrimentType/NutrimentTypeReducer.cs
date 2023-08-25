using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    public static class NutrimentTypeReducer
    {
        [ReducerMethod(typeof(AddNutrimentTypeAction))]
        public static NutrimentTypeState ReduceAddNutrimentTypeAction(NutrimentTypeState initialState) => new NutrimentTypeState(initialState.Count + 1);
    }
}
