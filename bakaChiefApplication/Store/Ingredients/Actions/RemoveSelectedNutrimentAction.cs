namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class RemoveSelectedNutrimentAction
    {
        public Models.Nutriment NutrimentType { get; }

        public RemoveSelectedNutrimentAction(Models.Nutriment nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
