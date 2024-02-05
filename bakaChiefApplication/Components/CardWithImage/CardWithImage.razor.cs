using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.CardWithImage;

public partial class CardWithImage
{
    [Parameter] public EventCallback OnClickCallback { get; set; }
    
    [Parameter] public string Title { get; set; }
    
    [Parameter] public string ImageUrl { get; set; }
    
    [Parameter] public Enums.Size ImageSize { get; set; } = Enums.Size.Normal;

    private async Task OnTagClick()
    {
        if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
    }
}