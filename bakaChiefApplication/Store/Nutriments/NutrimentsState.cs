using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments
{
    [FeatureState]
    public class NutrimentsState
    {
        public bool IsLoading { get; }

        public IEnumerable<Nutriment> Nutriments { get; }

        public string? NutrimentSearchTerm { get; }

        private NutrimentsState()
        {
            IsLoading = false;
            Nutriments = Enumerable.Empty<Nutriment>();
        }

        public NutrimentsState(NutrimentsState? currentState = null,  bool? isLoading = null, IEnumerable<Nutriment>? nutriments = null, string? nutrimentSearchTerm = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            Nutriments = nutriments != null ? nutriments : currentState != null ? currentState.Nutriments : Enumerable.Empty<Nutriment>();
            
            NutrimentSearchTerm = nutrimentSearchTerm != null ? nutrimentSearchTerm : currentState != null ? currentState.NutrimentSearchTerm : null;
        }
    }
}
