namespace bakaChiefApplication.Store.Nutriments.Actions;

public class NutrimentSearchByIdAction
{
    public string NutrimentSearchTerm { get; }

    public NutrimentSearchByIdAction(string nutrimentSearchTerm)
    {
        NutrimentSearchTerm = nutrimentSearchTerm;
    }
}