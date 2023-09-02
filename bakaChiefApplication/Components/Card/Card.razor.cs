using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Card
{
    public partial class Card
    {
        [Parameter] public string Title { get; set; }

        [Parameter] public RenderFragment Content { get; set; }

        [Parameter] public EventCallback OnClickCallback { get; set; }
        
        [Parameter] public bool IsRemovable { get; set; } = false;

        private async Task OnClick()
        {
            if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
