using bakaChiefApplication.ViewModels.NutrimentTypeViewModel;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.NutrimentTypes
{
    public partial class NutrimentTypes
    {
        [Inject]
        public INutrimentTypeViewModel ViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.Initialize();
        }
    }
}
