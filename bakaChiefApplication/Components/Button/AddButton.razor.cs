﻿using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.Button
{
    public partial class AddButton
    {
        [Parameter] public EventCallback OnClickCallback { get; set; }
        private async Task Onclick()
        {
            if (OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
