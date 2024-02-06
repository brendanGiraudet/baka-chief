namespace bakaChiefApplication.Store.BaseStore.Actions;

public class SearchByNameMoreAction<T>
{
    public string NameToSearch { get; }
    
    public int? Take { get; }
    
    public int? Skip { get; }

    public SearchByNameMoreAction(string nutrimentSearchTerm, int? take = null, int? skip = null)
    {
        NameToSearch = nutrimentSearchTerm;
        Take = take;
        Skip = skip;
    }
}