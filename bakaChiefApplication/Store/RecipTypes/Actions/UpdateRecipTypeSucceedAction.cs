using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class UpdateRecipTypeSucceedAction
{
    public RecipType UpdatedRecipType { get; set; }

    public UpdateRecipTypeSucceedAction(RecipType updatedRecipType)
    {
        UpdatedRecipType = updatedRecipType;
    }
}