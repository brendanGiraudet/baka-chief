using bakaChiefApplication.Store.ProductInfos.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.ProductInfos
{
    public static class ProductInfosReducer
    {
        #region ProductInfosFetchData
        [ReducerMethod(typeof(ProductInfosFetchDataAction))]
        public static ProductInfosState ReduceProductInfosFetchhDataAction(ProductInfosState state) => new ProductInfosState(isLoading: true);

        [ReducerMethod]
        public static ProductInfosState ReduceProductInfosFetchDataResultAction(ProductInfosState state, ProductInfosFetchDataResultAction action) => new ProductInfosState(isLoading: false, productInfos: action.ProductInfos);
        #endregion ProductInfosFetchData

        #region ProductInfoDetailsFetchData
        [ReducerMethod]
        public static ProductInfosState ReduceProductInfoDetailsFetchDataAction(ProductInfosState state, ProductInfoDetailsFetchDataAction action) => new ProductInfosState(productInfos: state.ProductInfos, productInfo: state.ProductInfos.FirstOrDefault(p => p.code == action.ProductInfoCode));
        #endregion
    }
}
