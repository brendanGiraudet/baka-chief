using bakaChiefApplication.Services.IngredientsService;
using bakaChiefApplication.Store.BaseStore;

namespace bakaChiefApplication.Store.Ingredients;

public class IngredientsEffect : BaseEffect<Models.Ingredient>
{
    public IngredientsEffect(IIngredientsService ingredientsService): base(ingredientsService)
    {
    }
}