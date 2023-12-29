using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients
{
    [FeatureState]
    public class IngredientsState
    {
        public bool IsLoading { get; }

        public IEnumerable<Ingredient> Ingredients { get; }
        
        public Ingredient Ingredient { get; }

        public string? IngredientSearchTerm { get; }

        private IngredientsState()
        {
            IsLoading = false;
            Ingredients = Enumerable.Empty<Ingredient>();
            Ingredient = new();
        }

        public IngredientsState(IngredientsState? currentState = null,  bool? isLoading = null, IEnumerable<Ingredient>? ingredients = null, string? ingredientSearchTerm = null, Ingredient? ingredient = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            Ingredients = ingredients != null ? ingredients : currentState != null ? currentState.Ingredients : Enumerable.Empty<Ingredient>();
            
            IngredientSearchTerm = ingredientSearchTerm != null ? ingredientSearchTerm : currentState != null ? currentState.IngredientSearchTerm : null;
            
            Ingredient = ingredient != null ? ingredient : currentState != null ? currentState.Ingredient : new();
        }
    }
}
