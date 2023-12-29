namespace bakaChiefApplication.Store.Nutriments.Actions;

public class NutrimentSearchByNameAction
{
    public string NutrimentSearchTerm { get; }

    public NutrimentSearchByNameAction(string nutrimentSearchTerm)
    {
        NutrimentSearchTerm = nutrimentSearchTerm;
    }
}