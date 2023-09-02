using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    [FeatureState]
    public class RecipsState
    {
        public bool IsLoading { get; }

        public bool IsRecipFormHidden { get; }

        public IEnumerable<Models.Recip> Recips { get; }
        
        public IEnumerable<Models.RecipIngredient> SelectedRecipIngredients { get; }
        
        public IEnumerable<Models.RecipStep> SelectedRecipSteps { get; }

        private RecipsState() { }

        public RecipsState(bool isLoading = false, IEnumerable<Models.Recip>? recips = null, bool isRecipFormHidden = true, IEnumerable<Models.RecipIngredient> selectedIngredients = null, IEnumerable<Models.RecipStep> selectedRecipSteps = null)
        {
            IsLoading = isLoading;
            Recips = recips ?? Enumerable.Empty<Models.Recip>();
            IsRecipFormHidden = isRecipFormHidden;
            SelectedRecipIngredients = selectedIngredients ?? Enumerable.Empty<Models.RecipIngredient>();
            SelectedRecipSteps = selectedRecipSteps ?? Enumerable.Empty<Models.RecipStep>();
        }
    }
}
