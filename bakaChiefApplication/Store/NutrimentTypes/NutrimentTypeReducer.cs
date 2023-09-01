using bakaChiefApplication.Store.NutrimentTypes.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.NutrimentTypes
{
    public static class NutrimentTypeReducer
    {
        [ReducerMethod(typeof(NutrimentTypeFetchhDataAction))]
        public static NutrimentTypesState ReduceNutrimentTypeFetchhDataAction(NutrimentTypesState state) => new NutrimentTypesState(isLoading: true);

        [ReducerMethod]
        public static NutrimentTypesState ReduceNutrimentTypeFetchDataResultAction(NutrimentTypesState state, NutrimentTypeFetchDataResultAction action) => new NutrimentTypesState(isLoading: false, nutrimentTypes: action.NutrimentTypes);

        [ReducerMethod(typeof(AddNutrimentTypeAction))]
        public static NutrimentTypesState ReduceAddNutrimentTypeAction(NutrimentTypesState state) => new NutrimentTypesState(isLoading: true, nutrimentTypes: state.NutrimentTypes, isNutrimentTypeFormHidden: true);
        
        [ReducerMethod]
        public static NutrimentTypesState ReduceAddNutrimentTypeResultAction(NutrimentTypesState state, AddNutrimentTypeResultAction action) => new NutrimentTypesState(isLoading: false, nutrimentTypes: state.NutrimentTypes.Append(action.NutrimentType));


        [ReducerMethod(typeof(DeleteNutrimentTypeAction))]
        public static NutrimentTypesState ReduceDeleteNutrimentTypeAction(NutrimentTypesState state) => new NutrimentTypesState(isLoading: true, nutrimentTypes: state.NutrimentTypes);

        [ReducerMethod]
        public static NutrimentTypesState ReduceDeleteNutrimentTypeResultAction(NutrimentTypesState state, DeleteNutrimentTypeResultAction action) => new NutrimentTypesState(isLoading:false, nutrimentTypes: state.NutrimentTypes.Where(n => n.Id != action.NutrimentTypeId));
        
        [ReducerMethod(typeof(ShowNutrimentTypeFormAction))]
        public static NutrimentTypesState ReduceShowNutrimentTypeFormAction(NutrimentTypesState state) => new NutrimentTypesState(nutrimentTypes: state.NutrimentTypes, isNutrimentTypeFormHidden: false);
        
        [ReducerMethod(typeof(CloseNutrimentTypeFormAction))]
        public static NutrimentTypesState ReduceCloseNutrimentTypeFormAction(NutrimentTypesState state) => new NutrimentTypesState(nutrimentTypes: state.NutrimentTypes, isNutrimentTypeFormHidden: true);
    }
}
