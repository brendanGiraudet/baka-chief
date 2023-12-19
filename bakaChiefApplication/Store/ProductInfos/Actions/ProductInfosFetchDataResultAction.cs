
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.ProductInfos.Actions
{
    public class ProductInfosFetchDataResultAction
    {
        public IEnumerable<ProductInfo> ProductInfos { get; set; }

        public ProductInfosFetchDataResultAction(IEnumerable<ProductInfo> productInfos)
        {
            ProductInfos = productInfos;
        }
    }
}
