using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Tag
{
    public partial class Tag
    {
        [Parameter]
        public string Content { get; set; }
        
        [Parameter]
        public bool IsAddable { get; set; } = false;

        [Parameter]
        public bool IsRemovable { get; set; } = false;
        
        [Parameter]
        public EventCallback OnClickCallback { get; set; }

        private async Task Onclick()
        {
            if (OnClickCallback.HasDelegate && (IsAddable || IsRemovable)) await OnClickCallback.InvokeAsync();
        }
    }
}
