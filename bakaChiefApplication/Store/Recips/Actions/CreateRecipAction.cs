using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class CreateRecipAction
    {
        public Models.Recip Recip { get; }

        public CreateRecipAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
