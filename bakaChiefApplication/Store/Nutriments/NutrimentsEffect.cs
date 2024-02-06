using bakaChiefApplication.Services.NutrimentsService;
using bakaChiefApplication.Store.BaseStore;

namespace bakaChiefApplication.Store.Nutriments;

public class NutrimentsEffect : BaseEffect<Models.Nutriment>
{
    public NutrimentsEffect(INutrimentsService nutrimentsService): base(nutrimentsService)
    {
    }
}