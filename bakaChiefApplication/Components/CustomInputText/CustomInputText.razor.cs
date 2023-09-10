using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace bakaChiefApplication.Components.CustomInputText
{
    public partial class CustomInputText : InputText
    {
        [Parameter] public string Label { get; set; }
        public string? test => !string.IsNullOrEmpty(FieldIdentifier.FieldName) ? FieldIdentifier.FieldName : Value;
    }
}
