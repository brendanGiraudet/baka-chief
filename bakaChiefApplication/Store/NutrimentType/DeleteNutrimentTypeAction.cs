namespace bakaChiefApplication.Store.NutrimentType
{
    public class DeleteNutrimentTypeAction
    {
        public string NutrimentTypeId { get; }

        public DeleteNutrimentTypeAction(string nitrumentTypeId)
        {
            NutrimentTypeId = nitrumentTypeId;
        }
    }
}
