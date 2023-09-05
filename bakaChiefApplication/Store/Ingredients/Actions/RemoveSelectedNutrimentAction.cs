namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class RemoveSelectedNutrimentAction
    {
        public Models.Nutriment Nutriment { get; }

        public RemoveSelectedNutrimentAction(Models.Nutriment nutrimentType)
        {
            Nutriment = nutrimentType;
        }
    }
}
