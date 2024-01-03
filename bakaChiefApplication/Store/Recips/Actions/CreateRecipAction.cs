using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class CreateRecipAction
{
    public Recip RecipToCreate { get; set; }

    public CreateRecipAction(Recip recipToCreate)
    {
        RecipToCreate = recipToCreate;
    }
}