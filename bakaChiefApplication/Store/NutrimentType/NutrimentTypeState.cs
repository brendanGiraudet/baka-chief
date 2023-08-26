using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    [FeatureState]
    public class NutrimentTypeState
    {
        public bool IsLoading { get; }

        public IEnumerable<Models.NutrimentType> NutrimentTypes { get; }

        private NutrimentTypeState() { }

        public NutrimentTypeState(bool isLoading, IEnumerable<Models.NutrimentType>? nutrimentTypes)
        {
            IsLoading = isLoading;
            NutrimentTypes = nutrimentTypes ?? Array.Empty<Models.NutrimentType>();
        }
    }
}
