using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Shared
{
    public partial class NavMenu
    {
        private bool _collapseNavMenu = true;
        private string _applicationVersion = string.Empty;

        [Inject] public IConfiguration Configuration { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _applicationVersion = Configuration["ApplicationVersion"];
        }

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
