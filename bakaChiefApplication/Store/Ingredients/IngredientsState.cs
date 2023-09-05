using Fluxor;

namespace bakaChiefApplication.Store.Ingredients
{
    [FeatureState]
    public class IngredientsState
    {
        public bool IsLoading { get; }
        
        public bool IsIngredientFormHidden { get; }

        public IEnumerable<Models.Ingredient> Ingredients { get; }
        
        public Models.Ingredient Ingredient { get; }
        
        private IngredientsState() { }

        public IngredientsState(bool isLoading = false, IEnumerable<Models.Ingredient>? ingredients = null, bool isIngredientFormHidden = true, Models.Ingredient ingredient = null)
        {
            IsLoading = isLoading;
            Ingredients = ingredients ?? Array.Empty<Models.Ingredient>();
            IsIngredientFormHidden = isIngredientFormHidden;
            Ingredient = ingredient ?? new Models.Ingredient();
        }
    }
}
