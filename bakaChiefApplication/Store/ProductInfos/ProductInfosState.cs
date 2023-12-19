using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.ProductInfos
{
    [FeatureState]
    public class ProductInfosState
    {
        public bool IsLoading { get; }
        
        public IEnumerable<ProductInfo> ProductInfos { get; }

        private ProductInfosState() { }

        public ProductInfosState(bool? isLoading = null, IEnumerable<ProductInfo>? productInfos = null)
        {
            System.Console.WriteLine($"products count: {productInfos?.Count()}");
            System.Console.WriteLine($"hashcode {GetHashCode()}");
            IsLoading = isLoading ?? false;
            ProductInfos = productInfos ?? Enumerable.Empty<ProductInfo>();
        }
    }
}
