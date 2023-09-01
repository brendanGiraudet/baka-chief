using Fluxor;

namespace bakaChiefApplication.Store.NutrimentTypes
{
    [FeatureState]
    public class NutrimentTypesState
    {
        public bool IsLoading { get; }
        
        public bool IsNutrimentTypeFormHidden { get; }

        public IEnumerable<Models.NutrimentType> NutrimentTypes { get; }

        private NutrimentTypesState() { }

        public NutrimentTypesState(bool isLoading = false, IEnumerable<Models.NutrimentType>? nutrimentTypes = null, bool isNutrimentTypeFormHidden = true)
        {
            IsLoading = isLoading;
            NutrimentTypes = nutrimentTypes ?? Array.Empty<Models.NutrimentType>();
            IsNutrimentTypeFormHidden = isNutrimentTypeFormHidden;
        }
    }
}
