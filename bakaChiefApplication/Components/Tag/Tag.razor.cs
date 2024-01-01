using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Tag
{
    public partial class Tag
    {
        [Parameter] public string Content { get; set; }
        
        [Parameter] public EventCallback OnClickCallback { get; set; }
        
        [Parameter] public Enums.Icon Icon { get; set; } = Enums.Icon.NotSet;
        
        [Parameter] public Enums.Style Style { get; set; } = Enums.Style.NotSet;
        
        [Parameter] public Enums.Size Size { get; set; } = Enums.Size.NotSet;

        private async Task Onclick()
        {
            if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
