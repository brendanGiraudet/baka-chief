using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments;

[FeatureState]
public class NutrimentsState : BaseState<Nutriment>
{
    private NutrimentsState():base()
    {
        
    }
    public NutrimentsState(NutrimentsState? currentState = null, bool? isLoading = null, IEnumerable<Nutriment>? items = null, string? nameToSearch = null, Nutriment? item = null, bool? needToReload = null) : base(currentState, isLoading, items, nameToSearch, item, needToReload)
    {

    }
}