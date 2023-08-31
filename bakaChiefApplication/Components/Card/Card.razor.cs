using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace bakaChiefApplication.Components.Card
{
    public partial class Card
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter] 
        public RenderFragment Content { get; set;}

        [Parameter]
        public EventCallback OnClickCallback { get; set; }

        private async Task OnCloseClick()
        {
            if(OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
