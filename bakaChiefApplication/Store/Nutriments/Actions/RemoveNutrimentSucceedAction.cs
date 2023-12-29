namespace bakaChiefApplication.Store.Nutriments.Actions;

public class RemoveNutrimentSucceedAction
{
    public string RemovedNutrimentId { get; }

    public RemoveNutrimentSucceedAction(string removedNutrimentId)
    {
        RemovedNutrimentId = removedNutrimentId;
    }
}