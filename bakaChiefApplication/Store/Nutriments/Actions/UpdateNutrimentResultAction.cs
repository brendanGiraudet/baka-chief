using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class UpdateNutrimentResultAction
    {
        public Models.Nutriment Nutriment { get; }

        public UpdateNutrimentResultAction(Nutriment nutriment)
        {
            Nutriment = nutriment;
        }
    }
}
