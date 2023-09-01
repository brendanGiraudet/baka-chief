using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class AddRecipAction
    {
        public Models.Recip Recip { get; }

        public AddRecipAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
