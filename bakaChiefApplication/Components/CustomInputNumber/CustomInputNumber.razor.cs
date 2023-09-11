using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace bakaChiefApplication.Components.CustomInputNumber
{
    public partial class CustomInputNumber : InputNumber<int?>
    {
        [Parameter] public string Label { get; set; }
    }
}
