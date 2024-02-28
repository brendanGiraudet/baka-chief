using bakaChiefApplication.Configurations;
using bakaChiefApplication.Constants;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.SelectedRecipHistories;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace bakaChiefApplication.Pages.SelectedRecipHistories;

public partial class SelectedRecipHistories
{
    [Inject] public IState<SelectedRecipHistoriesState> SelectedRecipHistoriesState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IOptions<SearchConfiguration> SearchConfigurationOptions { get; set; }

    SearchConfiguration SearchConfiguration => SearchConfigurationOptions.Value;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new SearchByNameMoreAction<Models.SelectedRecipHistory>(SelectedRecipHistoriesState.Value.NameToSearch, SearchConfiguration.DefaultNumberOfItemsToTake, SelectedRecipHistoriesState.Value.Items.Count()));
    }

    private async Task GenerateSelectedRecipHistory()
    {
        Dispatcher.Dispatch(new CreateAction<Models.SelectedRecipHistory>(null));

        await Task.CompletedTask;
    }

    private async Task RedirectToSelectedRecipHistoryPage(string id)
    {
        NavigationManager.NavigateTo(PagesUrl.GetSelectedRecipHistoryUrl(id));
    }
}