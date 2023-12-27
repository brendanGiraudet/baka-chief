
namespace bakaChiefApplication.Store.ProductInfos.Actions
{
    public class ProductInfoSearchByNameFetchDataAction
    {
        public string ProductInfoName { get; }
        public ProductInfoSearchByNameFetchDataAction(string productInfoName)
        {
            ProductInfoName = productInfoName;
        }
    }
}
