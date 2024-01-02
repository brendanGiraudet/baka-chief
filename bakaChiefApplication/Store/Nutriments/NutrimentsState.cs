using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments
{
    [FeatureState]
    public class NutrimentsState
    {
        public bool IsLoading { get; }

        public IEnumerable<Nutriment> Nutriments { get; }
        
        public Nutriment Nutriment { get; }

        public string? NutrimentSearchTerm { get; }

        public bool? NeedToReload { get; }

        private NutrimentsState()
        {
            IsLoading = false;
            Nutriments = Enumerable.Empty<Nutriment>();
            Nutriment = new();
        }

        public NutrimentsState(NutrimentsState? currentState = null,  bool? isLoading = null, IEnumerable<Nutriment>? nutriments = null, string? nutrimentSearchTerm = null, Nutriment? nutriment = null, bool? needToReload = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            Nutriments = nutriments != null ? nutriments : currentState != null ? currentState.Nutriments : Enumerable.Empty<Nutriment>();
            
            NutrimentSearchTerm = nutrimentSearchTerm != null ? nutrimentSearchTerm : currentState != null ? currentState.NutrimentSearchTerm : null;
            
            Nutriment = nutriment != null ? nutriment : currentState != null ? currentState.Nutriment : new();

            NeedToReload = needToReload != null ? needToReload : currentState != null ? currentState.NeedToReload : true;
        }
    }
}
