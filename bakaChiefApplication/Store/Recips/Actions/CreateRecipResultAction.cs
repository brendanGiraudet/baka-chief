using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class CreateRecipResultAction
    {
        public Recip Recip { get; }

        public CreateRecipResultAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
