namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class DeleteNutrimentAction
    {
        public string NutrimentId { get; }

        public DeleteNutrimentAction(string nitrumentTypeId)
        {
            NutrimentId = nitrumentTypeId;
        }
    }
}
