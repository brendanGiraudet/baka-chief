using Fluxor;

namespace bakaChiefApplication.Store.Ingredients
{
    [FeatureState]
    public class IngredientsState
    {
        public bool IsLoading { get; }
        
        public bool IsIngredientFormHidden { get; }

        public IEnumerable<Models.Ingredient> Ingredients { get; }
        
        public IEnumerable<Models.NutrimentType> SelectedNutrimentType { get; }

        private IngredientsState() { }

        public IngredientsState(bool isLoading = false, IEnumerable<Models.Ingredient>? ingredients = null, bool isIngredientFormHidden = true, IEnumerable<Models.NutrimentType> selectedNutrimentTypes = null)
        {
            IsLoading = isLoading;
            Ingredients = ingredients ?? Array.Empty<Models.Ingredient>();
            IsIngredientFormHidden = isIngredientFormHidden;
            SelectedNutrimentType = selectedNutrimentTypes ?? Enumerable.Empty<Models.NutrimentType>();
        }
    }
}
