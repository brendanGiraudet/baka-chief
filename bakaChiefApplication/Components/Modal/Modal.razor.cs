using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Modal
{
    public partial class Modal
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public bool Hidden { get; set; }

        [Parameter]
        public EventCallback OnCloseCallback { get; set; }

        private async Task OnCloseClick()
        {
            if (OnCloseCallback.HasDelegate) await OnCloseCallback.InvokeAsync();
        }
    }
}
