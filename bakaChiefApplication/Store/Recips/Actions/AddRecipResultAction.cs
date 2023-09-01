using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class AddRecipResultAction
    {
        public Recip Recip { get; }

        public AddRecipResultAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
