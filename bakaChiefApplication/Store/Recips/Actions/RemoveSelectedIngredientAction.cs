using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RemoveSelectedProductInfoAction
    {
        public Models.RecipProductInfo RecipProductInfo { get; }

        public RemoveSelectedProductInfoAction(RecipProductInfo recipProductInfo)
        {
            RecipProductInfo = recipProductInfo;
        }
    }
}
