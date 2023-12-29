namespace bakaChiefApplication.Store.Nutriments.Actions;

public class RemoveNutrimentAction
{
    public string NutrimentIdToRemove { get; }

    public RemoveNutrimentAction(string nutrimentIdToRemove)
    {
        NutrimentIdToRemove = nutrimentIdToRemove;
    }
}