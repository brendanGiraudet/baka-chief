namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class NutrimentsFetchDataResultAction
    {
        public Models.Nutriment[] Nutriments { get; }

        public NutrimentsFetchDataResultAction(Models.Nutriment[] nutrimentTypes)
        {
            Nutriments = nutrimentTypes;
        }
    }
}