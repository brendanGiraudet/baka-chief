namespace bakaChiefApplication.Shared
{
    public partial class NavMenu
    {
        private bool _collapseNavMenu = true;

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
