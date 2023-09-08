using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RecipsFetchDataResultAction
    {
        public IEnumerable<Recip> Recips { get; }

        public RecipsFetchDataResultAction(IEnumerable<Recip> recips)
        {
            Recips = recips;
        }
    }
}
