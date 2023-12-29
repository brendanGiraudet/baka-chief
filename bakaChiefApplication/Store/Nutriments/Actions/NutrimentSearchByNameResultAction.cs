namespace bakaChiefApplication.Store.Nutriments.Actions;

public class NutrimentSearchByNameResultAction
{
    public IEnumerable<Models.Nutriment> SearchedNutriments { get; }

    public NutrimentSearchByNameResultAction(IEnumerable<Models.Nutriment> searchedNutriments)
    {
        SearchedNutriments = searchedNutriments;
    }
}