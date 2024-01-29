using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class CreateRecipTypeSucceedAction
{
    public RecipType CreatedRecipType { get; set; }

    public CreateRecipTypeSucceedAction(RecipType createdRecipType)
    {
        CreatedRecipType = createdRecipType;
    }
}