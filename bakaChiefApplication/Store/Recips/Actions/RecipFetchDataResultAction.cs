using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RecipFetchDataResultAction
    {
        public IEnumerable<Recip> Recips { get; }

        public RecipFetchDataResultAction(IEnumerable<Recip> recips)
        {
            Recips = recips;
        }
    }
}
