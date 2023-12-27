using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.ProductInfos
{
    [FeatureState]
    public class ProductInfosState
    {
        public bool IsLoading { get; }

        public IEnumerable<ProductInfo> ProductInfos { get; }

        public ProductInfo? CurrentProductInfo { get; }

        public string? ProductInfoSearchTerm { get; }

        private ProductInfosState()
        {
            IsLoading = false;
            ProductInfos = Enumerable.Empty<ProductInfo>();
        }

        public ProductInfosState(ProductInfosState? currentState = null,  bool? isLoading = null, IEnumerable<ProductInfo>? productInfos = null, ProductInfo? currentProductInfo = null, string? productInfoSearchTerm = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            ProductInfos = productInfos != null ? productInfos : currentState != null ? currentState.ProductInfos : Enumerable.Empty<ProductInfo>();
            
            CurrentProductInfo = currentProductInfo != null ? currentProductInfo : currentState != null ? currentState.CurrentProductInfo : null;
            
            ProductInfoSearchTerm = productInfoSearchTerm != null ? productInfoSearchTerm : currentState != null ? currentState.ProductInfoSearchTerm : null;
        }
    }
}
