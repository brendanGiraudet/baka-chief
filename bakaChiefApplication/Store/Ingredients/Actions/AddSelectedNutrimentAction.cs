namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class AddSelectedNutrimentAction
    {
        public Models.NutrimentType NutrimentType { get; }

        public AddSelectedNutrimentAction(Models.NutrimentType nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
