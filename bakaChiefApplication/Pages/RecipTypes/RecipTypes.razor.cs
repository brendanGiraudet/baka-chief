using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.RecipTypes;

public partial class RecipTypes
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    private async Task RedirectToRecipTypeForm(FormMode formMode, string? RecipTypeId = null)
    {
        NavigationManager.NavigateTo(PagesUrl.GetRecipTypeFormUrl(formMode, RecipTypeId));

        await Task.CompletedTask;
    }
}
