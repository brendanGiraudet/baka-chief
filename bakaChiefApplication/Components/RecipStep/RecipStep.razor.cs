using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.RecipStep;

public partial class RecipStep
{
    [Parameter] public Models.RecipStep CurrentRecipStep { get; set; }
    [Parameter] public Enums.Icon Icon { get; set; }
    [Parameter] public Enums.Size Size { get; set; }
    [Parameter] public Enums.Style Style { get; set; }
    [Parameter] public EventCallback OnIconClickCallback { get; set; }

    private async Task OnIconClick()
    {
        if (OnIconClickCallback.HasDelegate) await OnIconClickCallback.InvokeAsync();
    }
}