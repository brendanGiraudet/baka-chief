using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore;
using Fluxor;

namespace bakaChiefApplication.Store.MeasureUnits;

[FeatureState]
public class MeasureUnitsState : BaseState<MeasureUnit>
{
    private MeasureUnitsState():base()
    {
        
    }
    public MeasureUnitsState(MeasureUnitsState? currentState = null, bool? isLoading = null, IEnumerable<MeasureUnit>? items = null, string? nameToSearch = null, MeasureUnit? item = null, bool? needToReload = null) : base(currentState, isLoading, items, nameToSearch, item, needToReload)
    {

    }
}