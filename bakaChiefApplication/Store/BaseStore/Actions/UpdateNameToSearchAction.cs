namespace bakaChiefApplication.Store.Ingredients.Actions;

public class UpdateNameToSearchAction<T>
{
    public string NameToSearch { get; set; }

    public UpdateNameToSearchAction(string nameToSearch)
    {
        NameToSearch = nameToSearch;
    }
}