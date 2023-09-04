namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class NutrimentsFetchDataResultAction
    {
        public IEnumerable<Models.Nutriment> Nutriments { get; }

        public NutrimentsFetchDataResultAction(IEnumerable<Models.Nutriment> nutrimentTypes)
        {
            Nutriments = nutrimentTypes;
        }
    }
}