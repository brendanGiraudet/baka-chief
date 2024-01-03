using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class CreateRecipSucceedAction
{
    public Recip CreatedRecip { get; set; }

    public CreateRecipSucceedAction(Recip createdRecip)
    {
        CreatedRecip = createdRecip;
    }
}