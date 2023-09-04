using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class NutrimentFetchDataResultAction
    {
        public Models.Nutriment Nutriment { get; }

        public NutrimentFetchDataResultAction(Nutriment nutriment)
        {
            Nutriment = nutriment;
        }
    }
}
