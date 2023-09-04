namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class NutrimentFetchDataAction
    {
        public string NutrimentId { get; }

        public NutrimentFetchDataAction(string nutrimentId)
        {
            NutrimentId = nutrimentId;
        }
    }
}
