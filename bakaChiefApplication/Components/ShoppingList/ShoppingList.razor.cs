using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.ShoppingList;

public partial class ShoppingList
{
    [Parameter] public IEnumerable<Models.Recip> Recips { get; set; }

    private IEnumerable<Models.RecipIngredient> _recipIngredients = Enumerable.Empty<Models.RecipIngredient>();

    private Dictionary<string, ShoppingIngredientStatus> _ingredientsStatus;

    protected override async Task OnInitializedAsync()
    {
        base.OnInitializedAsync();

        foreach (var recip in Recips) 
        {
            var ingredients = _recipIngredients.Concat(recip.RecipIngredients);
            _recipIngredients = ingredients.GroupBy(r => r.Ingredient?.Name, r => r, (baseName, recipIngredients)=> new Models.RecipIngredient
            {
                Ingredient = recipIngredients?.FirstOrDefault().Ingredient,
                Quantity = recipIngredients?.Sum(i => i.Quantity) ?? 0,
                MeasureUnit = recipIngredients?.Where(i => i.MeasureUnit != null).FirstOrDefault()?.MeasureUnit
            });
        }

        _ingredientsStatus = _recipIngredients.ToDictionary(r => r.Ingredient.Id, r => ShoppingIngredientStatus.NA);
    }

    private string GetIngredientStatusClass(string ingredientId) => $"ingredient-status-{_ingredientsStatus[ingredientId].ToString().ToLower()}";

    private void ChangeStatus(string ingredientId) => _ingredientsStatus[ingredientId] = _ingredientsStatus[ingredientId] == ShoppingIngredientStatus.NA ? ShoppingIngredientStatus.Take : _ingredientsStatus[ingredientId] == ShoppingIngredientStatus.Take ? ShoppingIngredientStatus.Unexist : ShoppingIngredientStatus.NA;
}

public enum ShoppingIngredientStatus
{
    NA,
    Take,
    Unexist
}
