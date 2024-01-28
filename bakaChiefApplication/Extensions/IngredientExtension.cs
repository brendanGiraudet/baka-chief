using bakaChiefApplication.Models;

namespace bakaChiefApplication.Extensions;

public static class IngredientExtension
{
    public static Ingredient Format(this Ingredient ingredient)
    {
        ingredient.Name = ingredient.Name.ToLower();
        
        return ingredient;
    }
}