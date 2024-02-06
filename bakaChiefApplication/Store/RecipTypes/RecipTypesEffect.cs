using bakaChiefApplication.Services.RecipTypesService;
using bakaChiefApplication.Store.BaseStore;

namespace bakaChiefApplication.Store.RecipTypes;

public class RecipTypesEffect : BaseEffect<Models.RecipType>
{
    public RecipTypesEffect(IRecipTypesService recipTypesService) : base(recipTypesService)
    {
    }
}