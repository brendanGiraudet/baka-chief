using Fluxor;

namespace bakaChiefApplication.Store.Nutriments
{
    [FeatureState]
    public class NutrimentsState
    {
        public bool IsLoading { get; }
        
        public bool IsNutrimentFormHidden { get; }

        public IEnumerable<Models.Nutriment> Nutriments { get; }

        public Models.Nutriment Nutriment { get; }

        private NutrimentsState() { }

        public NutrimentsState(bool isLoading = false, IEnumerable<Models.Nutriment>? nutriments = null, bool isNutrimentFormHidden = true, Models.Nutriment? nutriment = null)
        {
            IsLoading = isLoading;
            Nutriments = nutriments ?? Array.Empty<Models.Nutriment>();
            IsNutrimentFormHidden = isNutrimentFormHidden;
            Nutriment = nutriment ?? new Models.Nutriment();
        }
    }
}
