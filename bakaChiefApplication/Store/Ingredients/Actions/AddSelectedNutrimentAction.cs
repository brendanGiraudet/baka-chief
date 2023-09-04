namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class AddSelectedNutrimentAction
    {
        public Models.Nutriment NutrimentType { get; }

        public AddSelectedNutrimentAction(Models.Nutriment nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
