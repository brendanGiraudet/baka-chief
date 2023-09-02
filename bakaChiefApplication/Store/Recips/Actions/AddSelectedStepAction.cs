using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Recips.Actions
{
    public class AddSelectedStepAction
    {
        public Models.RecipStep RecipStep { get; }

        public AddSelectedStepAction(RecipStep recipStep)
        {
            RecipStep = recipStep;
        }
    }
}
