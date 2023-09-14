using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Modal
{
    public partial class Modal
    {
        [Parameter] public RenderFragment Content { get; set; }

        [Parameter] public bool Hidden { get; set; }
        
        [Parameter] public string Title { get; set; }

        [Parameter] public EventCallback OnCloseCallback { get; set; }
        
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object>? AdditionalAttributes { get; set; }

        private async Task OnCloseClick()
        {
            await Console.Out.WriteLineAsync("coucou");
            if (OnCloseCallback.HasDelegate) await OnCloseCallback.InvokeAsync();
        }
    }
}
