using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore;
using Fluxor;

namespace bakaChiefApplication.Store.SelectedRecipHistories;

[FeatureState]
public class SelectedRecipHistoriesState : BaseState<SelectedRecipHistory>
{
    private SelectedRecipHistoriesState() : base()
    {

    }

    public SelectedRecipHistoriesState(SelectedRecipHistoriesState? currentState = null, bool? isLoading = null, IEnumerable<SelectedRecipHistory>? items = null, string? nameToSearch = null, SelectedRecipHistory? item = null, bool? needToReload = null) : base(currentState, isLoading, items, nameToSearch, item, needToReload)
    {

    }
}