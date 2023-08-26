using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    [FeatureState]
    public class NutrimentTypeState
    {
        public bool IsLoading { get; }
        
        public bool IsAddLoading { get; }

        public IEnumerable<Models.NutrimentType> NutrimentTypes { get; }

        private NutrimentTypeState() { }

        public NutrimentTypeState(bool isLoading, IEnumerable<Models.NutrimentType>? nutrimentTypes)
        {
            IsLoading = isLoading;
            NutrimentTypes = nutrimentTypes ?? Array.Empty<Models.NutrimentType>();
        }
        
        public NutrimentTypeState(bool isAddLoading, Models.NutrimentType? nutrimentType, IEnumerable<Models.NutrimentType>? nutrimentTypes)
        {
            IsAddLoading = isAddLoading;

            if(nutrimentType != null && NutrimentTypes != null) NutrimentTypes = NutrimentTypes.Append(nutrimentType);

            NutrimentTypes = nutrimentTypes;
        }
    }
}
