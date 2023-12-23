using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class AddSelectedProductInfoAction
    {
        public Models.RecipProductInfo RecipProductInfo { get; }

        public AddSelectedProductInfoAction(RecipProductInfo recipProductInfo)
        {
            RecipProductInfo = recipProductInfo;
        }
    }
}
