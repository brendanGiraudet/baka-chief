using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore;
using Fluxor;

namespace bakaChiefApplication.Store.RecipTypes;

    [FeatureState]
    public class RecipTypesState : BaseState<RecipType>
{
    private RecipTypesState() : base()
    {

    }

    public RecipTypesState(RecipTypesState? currentState = null, bool? isLoading = null, IEnumerable<RecipType>? items = null, string? nameToSearch = null, RecipType? item = null, bool? needToReload = null) : base(currentState, isLoading, items, nameToSearch, item, needToReload)
    {

    }
}