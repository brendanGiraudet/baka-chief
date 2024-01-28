using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace bakaChiefApplication.Components.CustomInputTextArea
{
    public partial class CustomInputTextArea : InputTextArea
    {
        [Parameter] public string Label { get; set; }
    }
}
