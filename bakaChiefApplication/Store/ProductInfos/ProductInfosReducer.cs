using bakaChiefApplication.Store.ProductInfos.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.ProductInfos;

public static class ProductInfosReducer
{
    #region ProductInfosFetchData
    [ReducerMethod(typeof(ProductInfosFetchDataAction))]
    public static ProductInfosState ReduceProductInfosFetchhDataAction(ProductInfosState state) => new ProductInfosState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static ProductInfosState ReduceProductInfosFetchDataResultAction(ProductInfosState state, ProductInfosFetchDataResultAction action) => new ProductInfosState(currentState: state, isLoading: false, productInfos: action.ProductInfos);
    #endregion ProductInfosFetchData

    #region ProductInfoDetailsFetchData
    [ReducerMethod]
    public static ProductInfosState ReduceProductInfoDetailsFetchDataAction(ProductInfosState state, ProductInfoDetailsFetchDataAction action) => new ProductInfosState(currentState: state, currentProductInfo: state.ProductInfos.FirstOrDefault(p => p.code == action.ProductInfoCode));
    #endregion

    #region ProductInfoSearchByName
    [ReducerMethod(typeof(ProductInfoSearchByNameFetchDataAction))]
    public static ProductInfosState ReduceProductInfoSearchByNameFetchDataAction(ProductInfosState state) => new ProductInfosState(currentState: state, isLoading: true);

    [ReducerMethod]
    public static ProductInfosState ReduceProductInfoSearchByNameFetchDataResultAction(ProductInfosState state, ProductInfoSearchByNameFetchDataResultAction action) => new ProductInfosState(currentState: state, isLoading: false, productInfos: action.ProductInfos);
    #endregion

    #region UpdateProductInfoSearchTermAction
    [ReducerMethod]
    public static ProductInfosState ReduceUpdateProductInfoSearchTermAction(ProductInfosState state, UpdateProductInfoSearchTermAction action) => new ProductInfosState(currentState: state, productInfoSearchTerm: action.ProductInfoSearchTerm);
    #endregion
}