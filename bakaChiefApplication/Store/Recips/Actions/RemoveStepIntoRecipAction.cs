using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class RemoveStepIntoRecipAction
{
    public RecipStep RemovedStep { get; set; }

    public RemoveStepIntoRecipAction(RecipStep removedStep)
    {
        RemovedStep = removedStep;
    }
}