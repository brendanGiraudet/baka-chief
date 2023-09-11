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
        public static NutrimentsState ReduceCreateNutrimentTypeResultAction(NutrimentsState state, CreateNutrimentResultAction action) => new NutrimentsState(isLoading: false, nutriments: state.Nutriments.Append(action.NutrimentType).ToArray());
        #endregion CreateNutriment

        #region DeleteNutriment
        [ReducerMethod(typeof(DeleteNutrimentAction))]
        public static NutrimentsState ReduceDeleteNutrimentAction(NutrimentsState state) => new NutrimentsState(isLoading: true, nutriments: state.Nutriments);

        [ReducerMethod]
        public static NutrimentsState ReduceDeleteNutrimentResultAction(NutrimentsState state, DeleteNutrimentResultAction action) => new NutrimentsState(isLoading: false, nutriments: state.Nutriments.Where(n => n.Id != action.NutrimentTypeId).ToArray());
        #endregion DeleteNutriment

        #region NutrimentForm
        [ReducerMethod(typeof(ShowNutrimentFormAction))]
        public static NutrimentsState ReduceShowNutrimentFormAction(NutrimentsState state) => new NutrimentsState(nutriments: state.Nutriments, isNutrimentFormHidden: false);

        [ReducerMethod(typeof(CloseNutrimentFormAction))]
        public static NutrimentsState ReduceCloseNutrimentFormAction(NutrimentsState state) => new NutrimentsState(nutriments: state.Nutriments, isNutrimentFormHidden: true);

        #endregion NutrimentForm

        #region NutrimentFetchDataAction
        [ReducerMethod(typeof(NutrimentFetchDataAction))]
        public static NutrimentsState ReduceNutrimentFetchDataAction(NutrimentsState state) => new NutrimentsState(isLoading: true, nutriments: state.Nutriments, isNutrimentFormHidden: false);

        [ReducerMethod]
        public static NutrimentsState ReduceNutrimentFetchDataResultAction(NutrimentsState state, NutrimentFetchDataResultAction action) => new NutrimentsState(isLoading: false, nutriments: state.Nutriments, isNutrimentFormHidden: false, nutriment: action.Nutriment);
        #endregion NutrimentFetchDataAction

        #region UpdateNutrimentAction
        [ReducerMethod(typeof(UpdateNutrimentAction))]
        public static NutrimentsState ReduceUpdateNutrimentAction(NutrimentsState state) => new NutrimentsState(isLoading: true, nutriments: state.Nutriments, isNutrimentFormHidden: false);

        [ReducerMethod]
        public static NutrimentsState ReduceUpdateNutrimentResultAction(NutrimentsState state, UpdateNutrimentResultAction action) 
        {
            var nutriments = state.Nutriments.Where(n => n.Id != action.Nutriment.Id);
            nutriments = nutriments.Append(action.Nutriment);

            return new NutrimentsState(isLoading: false, nutriments: nutriments.ToArray(), isNutrimentFormHidden: true);
        }
        #endregion UpdateNutrimentAction
    }
}
