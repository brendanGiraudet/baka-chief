namespace bakaChiefApplication.Store.NutrimentType.Actions
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
