using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class UpdateRecipAction
    {
        public Models.Recip Recip { get; }

        public UpdateRecipAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
