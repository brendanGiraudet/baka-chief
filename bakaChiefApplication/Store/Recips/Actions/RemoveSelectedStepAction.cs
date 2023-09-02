using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RemoveSelectedStepAction
    {
        public Models.RecipStep RecipStep { get; }

        public RemoveSelectedStepAction(RecipStep recipStep)
        {
            RecipStep = recipStep;
        }
    }
}
