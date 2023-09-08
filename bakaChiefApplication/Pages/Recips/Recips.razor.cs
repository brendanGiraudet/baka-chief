using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Recips
{
    public partial class Recips
    {
        [Inject] public IState<RecipsState> RecipsState { get; set; }

        [Inject] public IDispatcher Dispatcher { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new RecipsFetchDataAction());
        }

        private async Task RedirectToRecipForm(FormMode formMode, string recipId = null)
        {
            NavigationManager.NavigateTo(PagesUrl.GetRecipFormUrl(formMode, recipId));
        }
    }
}
