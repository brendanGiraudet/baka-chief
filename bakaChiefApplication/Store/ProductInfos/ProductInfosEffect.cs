using bakaChiefApplication.Services.ProductInfosService;
using bakaChiefApplication.Store.ProductInfos.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.ProductInfos
{
    public class ProductInfosEffect
    {
        IProductInfosService _productInfosService;

        public ProductInfosEffect(IProductInfosService productInfosService)
        {
            _productInfosService = productInfosService;
        }

        [EffectMethod(typeof(ProductInfosFetchDataAction))]
        public async Task HandleProductInfosFetchDataAction(IDispatcher dispatcher)
        {
            var products = await _productInfosService.GetProductsAsync();

            dispatcher.Dispatch(new ProductInfosFetchDataResultAction(products));
        }
        
        [EffectMethod]
        public async Task HandleProductInfoSearchByNameFetchDataAction(ProductInfoSearchByNameFetchDataAction action, IDispatcher dispatcher)
        {
            var products = await _productInfosService.GetProductsByNameAsync(action.ProductInfoName);

            dispatcher.Dispatch(new ProductInfoSearchByNameFetchDataResultAction(products));
        }
    }
}
