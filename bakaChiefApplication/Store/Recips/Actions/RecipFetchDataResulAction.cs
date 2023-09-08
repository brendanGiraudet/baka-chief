using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RecipFetchDataResulAction
    {
        public Models.Recip Recip { get; }

        public RecipFetchDataResulAction(Recip recip)
        {
            Recip = recip;
        }
    }
}
