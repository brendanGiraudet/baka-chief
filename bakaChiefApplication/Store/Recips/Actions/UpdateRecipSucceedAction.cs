using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class UpdateRecipSucceedAction
{
    public Recip UpdatedRecip { get; set; }

    public UpdateRecipSucceedAction(Recip updatedRecip)
    {
        UpdatedRecip = updatedRecip;
    }
}