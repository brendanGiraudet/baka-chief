using bakaChiefApplication.Services.MeasureUnitsService;
using bakaChiefApplication.Store.BaseStore;

namespace bakaChiefApplication.Store.MeasureUnits;

public class MeasureUnitsEffect : BaseEffect<Models.MeasureUnit>
{
    public MeasureUnitsEffect(IMeasureUnitsService measureUnitsService): base(measureUnitsService)
    {
    }
}