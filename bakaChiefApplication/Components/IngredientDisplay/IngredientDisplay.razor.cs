using bakaChiefApplication.Models;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.IngredientDisplay;

public partial class IngredientDisplay
{
    [Parameter] public EventCallback<Ingredient> OnClickCallback { get; set; }
    
    [Parameter] public Ingredient Ingredient { get; set; }

    private async Task OnTagClick(Ingredient clikedIngredient)
    {
        if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync(clikedIngredient);
    }
}