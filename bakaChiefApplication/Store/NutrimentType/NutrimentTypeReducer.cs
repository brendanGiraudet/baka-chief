using bakaChiefApplication.Store.NutrimentType.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    public static class NutrimentTypeReducer
    {
        [ReducerMethod(typeof(NutrimentTypeFetchhDataAction))]
        public static NutrimentTypeState ReduceNutrimentTypeFetchhDataAction(NutrimentTypeState state) => new NutrimentTypeState(isLoading: true, nutrimentTypes: null);

        [ReducerMethod]
        public static NutrimentTypeState ReduceNutrimentTypeFetchDataResultAction(NutrimentTypeState state, NutrimentTypeFetchDataResultAction action) => new NutrimentTypeState(isLoading: false, nutrimentTypes: action.NutrimentTypes);

        [ReducerMethod(typeof(AddNutrimentTypeAction))]
        public static NutrimentTypeState ReduceAddNutrimentTypeAction(NutrimentTypeState state) => new NutrimentTypeState(isLoading: true, nutrimentTypes: state.NutrimentTypes, isNutrimentTypeFormHidden: true);
        
        [ReducerMethod]
        public static NutrimentTypeState ReduceAddNutrimentTypeResultAction(NutrimentTypeState state, AddNutrimentTypeResultAction action) => new NutrimentTypeState(isLoading: false, nutrimentTypes: state.NutrimentTypes.Append(action.NutrimentType));


        [ReducerMethod(typeof(DeleteNutrimentTypeAction))]
        public static NutrimentTypeState ReduceDeleteNutrimentTypeAction(NutrimentTypeState state) => new NutrimentTypeState(isLoading: true, nutrimentTypes: state.NutrimentTypes);

        [ReducerMethod]
        public static NutrimentTypeState ReduceDeleteNutrimentTypeResultAction(NutrimentTypeState state, DeleteNutrimentTypeResultAction action) => new NutrimentTypeState(isLoading:false, nutrimentTypes: state.NutrimentTypes.Where(n => n.Id != action.NutrimentTypeId));
        
        [ReducerMethod(typeof(ShowNutrimentTypeFormAction))]
        public static NutrimentTypeState ReduceShowNutrimentTypeFormAction(NutrimentTypeState state) => new NutrimentTypeState(isLoading:false, nutrimentTypes: state.NutrimentTypes, isNutrimentTypeFormHidden: false);
        
        [ReducerMethod(typeof(CloseNutrimentTypeFormAction))]
        public static NutrimentTypeState ReduceCloseNutrimentTypeFormAction(NutrimentTypeState state) => new NutrimentTypeState(isLoading:false, nutrimentTypes: state.NutrimentTypes, isNutrimentTypeFormHidden: true);
    }
}
