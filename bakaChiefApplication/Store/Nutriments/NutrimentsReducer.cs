using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments
{
    public static class NutrimentsReducer
    {
        #region NutrimentsFetchData
        [ReducerMethod(typeof(NutrimentsFetchDataAction))]
        public static NutrimentsState ReduceNutrimentTypeFetchhDataAction(NutrimentsState state) => new NutrimentsState(isLoading: true);

        [ReducerMethod]
        public static NutrimentsState ReduceNutrimentTypeFetchDataResultAction(NutrimentsState state, NutrimentsFetchDataResultAction action) => new NutrimentsState(isLoading: false, nutriments: action.Nutriments);
        #endregion NutrimentsFetchData

        #region CreateNutriment
        [ReducerMethod(typeof(CreateNutrimentAction))]
        public static NutrimentsState ReduceCreateNutrimentAction(NutrimentsState state) => new NutrimentsState(isLoading: true, nutriments: state.Nutriments, isNutrimentFormHidden: true);
        
        [ReducerMethod]
        public static NutrimentsState ReduceCreateNutrimentTypeResultAction(NutrimentsState state, CreateNutrimentResultAction action) => new NutrimentsState(isLoading: false, nutriments: state.Nutriments.Append(action.NutrimentType));
        #endregion CreateNutriment

        #region DeleteNutriment
        [ReducerMethod(typeof(DeleteNutrimentAction))]
        public static NutrimentsState ReduceDeleteNutrimentAction(NutrimentsState state) => new NutrimentsState(isLoading: true, nutriments: state.Nutriments);

        [ReducerMethod]
        public static NutrimentsState ReduceDeleteNutrimentResultAction(NutrimentsState state, DeleteNutrimentResultAction action) => new NutrimentsState(isLoading:false, nutriments: state.Nutriments.Where(n => n.Id != action.NutrimentTypeId));
        #endregion DeleteNutriment

        #region NutrimentForm
        [ReducerMethod(typeof(ShowNutrimentFormAction))]
        public static NutrimentsState ReduceShowNutrimentFormAction(NutrimentsState state) => new NutrimentsState(nutriments: state.Nutriments, isNutrimentFormHidden: false);
        
        [ReducerMethod(typeof(CloseNutrimentFormAction))]
        public static NutrimentsState ReduceCloseNutrimentFormAction(NutrimentsState state) => new NutrimentsState(nutriments: state.Nutriments, isNutrimentFormHidden: true);

        #endregion NutrimentForm
    }
}
