using bakaChiefApplication.Enums;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Button
{
    public partial class Button
    {
        [Parameter] public string Text { get; set; } = string.Empty;

        [Parameter] public string Type { get; set; } = string.Empty;

        [Parameter] public EventCallback OnClickCallback { get; set; }

        // BUTTON STYLE
        [Parameter] public Style ButtonStyle { get; set; } = Style.Primary;
        private string _buttonStyleClass => ButtonStyle.ToString().ToLower();

        // BUTTON SIZE
        [Parameter] public Size ButtonSize { get; set; } = Size.Normal;
        private string _buttonSizeClass => ButtonSize.ToString().ToLower();

        private async Task Onclick()
        {
            if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
