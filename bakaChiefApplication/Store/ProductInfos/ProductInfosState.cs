using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.ProductInfos
{
    [FeatureState]
    public class ProductInfosState
    {
        public bool IsLoading { get; }
        
        public IEnumerable<ProductInfo> ProductInfos { get; }

        public ProductInfo CurrentProductInfo { get; }

        private ProductInfosState() { }

        public ProductInfosState(bool? isLoading = null, IEnumerable<ProductInfo>? productInfos = null, ProductInfo productInfo = null)
        {
            IsLoading = isLoading ?? false;
            ProductInfos = productInfos ?? Enumerable.Empty<ProductInfo>();
            CurrentProductInfo = productInfo;
        }
    }
}
