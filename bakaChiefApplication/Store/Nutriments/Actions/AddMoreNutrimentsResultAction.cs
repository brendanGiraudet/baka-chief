namespace bakaChiefApplication.Store.Nutriments.Actions;

public class AddMoreNutrimentsResultAction
{
    public IEnumerable<Models.Nutriment> SearchedNutriments { get; }

    public AddMoreNutrimentsResultAction(IEnumerable<Models.Nutriment> searchedNutriments)
    {
        SearchedNutriments = searchedNutriments;
    }
}