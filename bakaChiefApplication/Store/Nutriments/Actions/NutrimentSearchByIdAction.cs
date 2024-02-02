namespace bakaChiefApplication.Store.Nutriments.Actions;

public class NutrimentSearchByIdAction
{
    public string NutrimentId { get; }

    public NutrimentSearchByIdAction(string nutrimentId)
    {
        NutrimentId = nutrimentId;
    }
}