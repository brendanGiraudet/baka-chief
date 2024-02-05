namespace bakaChiefApplication.Store.BaseStore.Actions;

public class SearchByNameAction<T>
{
    public string NameToSearch { get; }
    
    public int? Take { get; }
    
    public int? Skip { get; }

    public SearchByNameAction(string nutrimentSearchTerm, int? take = null, int? skip = null)
    {
        NameToSearch = nutrimentSearchTerm;
        Take = take;
        Skip = skip;
    }
}