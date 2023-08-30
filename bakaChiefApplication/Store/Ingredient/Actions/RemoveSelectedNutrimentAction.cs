namespace bakaChiefApplication.Store.Ingredient.Actions
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
