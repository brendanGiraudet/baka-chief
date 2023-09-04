namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class UpdateNutrimentAction
    {
        public Models.Nutriment Nutriment { get; }

        public UpdateNutrimentAction(Models.Nutriment nutriment)
        {
            Nutriment = nutriment;
        }
    }
}
