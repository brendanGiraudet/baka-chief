namespace bakaChiefApplication.Store.NutrimentType.Actions
{
    public class AddNutrimentTypeResultAction
    {
        public Models.NutrimentType NutrimentType { get; }

        public AddNutrimentTypeResultAction(Models.NutrimentType nutrimentType)
        {
            NutrimentType = nutrimentType;
        }
    }
}
