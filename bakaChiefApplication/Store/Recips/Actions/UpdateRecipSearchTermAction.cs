namespace bakaChiefApplication.Store.Recips.Actions;

public class UpdateRecipSearchTermAction
{
    public string RecipSearchTerm { get; set; }

    public UpdateRecipSearchTermAction(string recipSearchTerm)
    {
        RecipSearchTerm = recipSearchTerm;
    }
}