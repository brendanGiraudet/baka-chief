using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions;

public class AppendStepIntoRecipAction
{
    public RecipStep SelectedStep { get; set; }

    public AppendStepIntoRecipAction(RecipStep selectedStep)
    {
        SelectedStep = selectedStep;
    }
}