
namespace bakaChiefApplication.Store.ProductInfos.Actions
{
    public class ProductInfoDetailsFetchDataAction
    {
        public string ProductInfoCode { get; }
        public ProductInfoDetailsFetchDataAction(string productInfoCode)
        {
            ProductInfoCode = productInfoCode;
        }
    }
}
