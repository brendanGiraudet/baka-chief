using Fluxor;

namespace bakaChiefApplication.Store.Ingredient
{
    [FeatureState]
    public class IngredientState
    {
        public bool IsLoading { get; }

        public IEnumerable<Models.Ingredient> Ingredients { get; }

        private IngredientState() { }

        public IngredientState(bool isLoading, IEnumerable<Models.Ingredient>? ingredients)
        {
            IsLoading = isLoading;
            Ingredients = ingredients ?? Array.Empty<Models.Ingredient>();
        }
    }
}
