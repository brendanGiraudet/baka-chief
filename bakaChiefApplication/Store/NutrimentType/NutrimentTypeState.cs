using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    [FeatureState]
    public class NutrimentTypeState
    {
        public int Count { get; set; }

        private NutrimentTypeState() { }

        public NutrimentTypeState(int count)
        {
            Count = count;
        }
    }
}
