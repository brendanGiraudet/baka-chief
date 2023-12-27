
namespace bakaChiefApplication.Store.ProductInfos.Actions
{
    public class ProductInfoSearchByNameFetchDataResultAction
    {
        public IEnumerable<Models.ProductInfo> ProductInfos { get; }
        public ProductInfoSearchByNameFetchDataResultAction(IEnumerable<Models.ProductInfo> productInfos)
        {
            ProductInfos = productInfos;
        }
    }
}
