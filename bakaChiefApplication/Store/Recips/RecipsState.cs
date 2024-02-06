using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore;
using Fluxor;

namespace bakaChiefApplication.Store.Recips;

[FeatureState]
public class RecipsState: BaseState<Recip>
{
    private RecipsState() : base()
    {

    }
    
    public RecipsState(RecipsState? currentState = null, bool? isLoading = null, IEnumerable<Recip>? items = null, string? nameToSearch = null, Recip? item = null, bool? needToReload = null) : base(currentState, isLoading, items, nameToSearch, item, needToReload)
    {

    }
}