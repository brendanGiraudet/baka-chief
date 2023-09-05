namespace bakaChiefApplication.Store.Ingredients.Actions
{
    public class AddSelectedNutrimentAction
    {
        public Models.Nutriment Nutriment { get; }

        public AddSelectedNutrimentAction(Models.Nutriment nutrimentType)
        {
            Nutriment = nutrimentType;
        }
    }
}
