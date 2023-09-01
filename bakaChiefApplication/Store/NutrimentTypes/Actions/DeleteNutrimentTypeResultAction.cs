namespace bakaChiefApplication.Store.NutrimentTypes.Actions
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
