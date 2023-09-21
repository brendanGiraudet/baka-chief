using bakaChiefApplication.Enums;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Button
{
    public partial class Button
    {
        [Parameter] public string Text { get; set; }
        
        [Parameter] public string Type { get; set; }
        
        [Parameter] public EventCallback OnClickCallback { get; set; }

        // BUTTON STYLE
        [Parameter] public Style ButtonStyle { get; set; }
        private string _buttonStyleClass => ButtonStyle.ToString().ToLower();

        private async Task Onclick()
        {
            if(OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
