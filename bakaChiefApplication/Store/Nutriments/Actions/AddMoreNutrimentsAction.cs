namespace bakaChiefApplication.Store.Nutriments.Actions;

public class AddMoreNutrimentsAction
{
    public string NutrimentsearchTerm { get; }
    
    public int Take { get; }
    
    public int Skip { get; }

    public AddMoreNutrimentsAction(string nutrimentsearchTerm, int take, int skip)
    {
        NutrimentsearchTerm = nutrimentsearchTerm;
        Take = take;
        Skip = skip;
    }
}