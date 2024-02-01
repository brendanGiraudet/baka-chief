namespace bakaChiefApplication.Store.Nutriments.Actions;

public class NutrimentSearchByNameAction
{
    public string NutrimentSearchTerm { get; }
    
    public int Take { get; }

    public NutrimentSearchByNameAction(string nutrimentSearchTerm, int take)
    {
        NutrimentSearchTerm = nutrimentSearchTerm;
        Take = take;
    }
}