using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    [FeatureState]
    public class RecipsState
    {
        public bool IsLoading { get; }

        public bool IsRecipFormHidden { get; }

        public IEnumerable<Models.Recip> Recips { get; }
        
        public IEnumerable<Models.Ingredient> SelectedIngredients { get; }

        private RecipsState() { }

        public RecipsState(bool isLoading = false, IEnumerable<Models.Recip>? recips = null, bool isRecipFormHidden = true, IEnumerable<Models.Ingredient> selectedIngredients = null)
        {
            IsLoading = isLoading;
            Recips = recips ?? Enumerable.Empty<Models.Recip>();
            IsRecipFormHidden = isRecipFormHidden;
            SelectedIngredients = selectedIngredients ?? Enumerable.Empty<Models.Ingredient>();
        }
    }
}
