namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class RemoveSelectedNutrimentAction
    {
        public Models.NutrimentType NutrimentType { get; }

        public RemoveSelectedNutrimentAction(Models.NutrimentType nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
