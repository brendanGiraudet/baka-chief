using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class UpdateRecipTypeAction
{
    public Models.RecipType RecipTypeToUpdate { get; set; }

    public UpdateRecipTypeAction(RecipType recipTypeToUpdate)
    {
        RecipTypeToUpdate = recipTypeToUpdate;
    }
}