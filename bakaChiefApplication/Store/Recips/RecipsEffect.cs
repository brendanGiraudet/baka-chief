using bakaChiefApplication.Services.RecipsService;
using bakaChiefApplication.Store.BaseStore;

namespace bakaChiefApplication.Store.Recips;

public class RecipsEffect : BaseEffect<Models.Recip>
{
    public RecipsEffect(IRecipsService recipsService) : base(recipsService)
    {
    }
}