using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.FlottedButton
{
    public partial class FlottedButton
    {
        [Parameter] public EventCallback OnClickCallback { get; set; }
        
        [Parameter] public string? Text { get; set; }

        private async Task Onclick()
        {
            if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
