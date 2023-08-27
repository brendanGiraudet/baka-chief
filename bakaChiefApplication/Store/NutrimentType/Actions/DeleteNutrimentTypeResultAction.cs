namespace bakaChiefApplication.Store.NutrimentType.Actions
{
    public class DeleteNutrimentTypeResultAction
    {
        public string NutrimentTypeId { get; }

        public DeleteNutrimentTypeResultAction(string nitrumentTypeId)
        {
            NutrimentTypeId = nitrumentTypeId;
        }
    }
}
