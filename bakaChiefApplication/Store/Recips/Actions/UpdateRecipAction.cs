using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class UpdateRecipAction
{
    public Recip RecipToUpdate { get; set; }

    public UpdateRecipAction(Recip recipToUpdate)
    {
        RecipToUpdate = recipToUpdate;
    }
}