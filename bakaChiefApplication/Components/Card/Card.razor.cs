using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Card
{
    public partial class Card
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter] 
        public string CardSvgImage { get; set;}
    }
}
