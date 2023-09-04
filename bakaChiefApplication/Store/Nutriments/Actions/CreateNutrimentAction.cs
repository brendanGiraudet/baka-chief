namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class CreateNutrimentAction
    {
        public Models.Nutriment NutrimentType { get; }

        public CreateNutrimentAction(Models.Nutriment nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
