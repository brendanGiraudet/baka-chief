using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Button
{
    public partial class Button
    {
        [Parameter]
        public string Text { get; set; }
        
        [Parameter]
        public string Type { get; set; }
        
        [Parameter]
        public EventCallback OnClickCallback { get; set; }


        private async Task Onclick()
        {
            if(OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
