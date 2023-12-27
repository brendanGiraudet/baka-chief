
namespace bakaChiefApplication.Store.ProductInfos.Actions
{
    public class UpdateProductInfoSearchTermAction
    {
        public string? ProductInfoSearchTerm { get; set; }

        public UpdateProductInfoSearchTermAction(string? productInfoSearchTerm)
        {
            ProductInfoSearchTerm = productInfoSearchTerm;
        }
    }
}
