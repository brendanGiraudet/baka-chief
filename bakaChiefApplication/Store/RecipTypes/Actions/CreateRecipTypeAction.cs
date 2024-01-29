using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.RecipTypes.Actions;

public class CreateRecipTypeAction
{
    public RecipType RecipTypeToCreate { get; set; }

    public CreateRecipTypeAction(RecipType recipTypeToCreate)
    {
        RecipTypeToCreate = recipTypeToCreate;
    }
}