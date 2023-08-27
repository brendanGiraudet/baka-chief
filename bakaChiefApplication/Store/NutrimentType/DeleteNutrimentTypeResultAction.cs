namespace bakaChiefApplication.Store.NutrimentType
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
