namespace bakaChiefApplication.Store.Nutriments.Actions
{
    public class DeleteNutrimentResultAction
    {
        public string NutrimentTypeId { get; }

        public DeleteNutrimentResultAction(string nitrumentTypeId)
        {
            NutrimentTypeId = nitrumentTypeId;
        }
    }
}
