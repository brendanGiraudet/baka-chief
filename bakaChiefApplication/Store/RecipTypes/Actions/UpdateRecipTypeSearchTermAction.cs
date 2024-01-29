namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class UpdateRecipTypeSearchTermAction
{
    public string RecipTypeSearchTerm { get; set; }

    public UpdateRecipTypeSearchTermAction(string recipTypeSearchTerm)
    {
        RecipTypeSearchTerm = recipTypeSearchTerm;
    }
}