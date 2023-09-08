using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class UpdateRecipResultAction
    {
        public Models.Recip Recip { get; }

        public UpdateRecipResultAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
