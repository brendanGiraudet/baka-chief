namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class CreateNutrimentResultAction
    {
        public Models.Nutriment NutrimentType { get; }

        public CreateNutrimentResultAction(Models.Nutriment nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
