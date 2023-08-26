using bakaChiefApplication.Services.NutrimentTypeService;
using Fluxor;

namespace bakaChiefApplication.Store.NutrimentType
{
    public class NutrimentTypeEffect
    {
        readonly INutrimentTypeService _nutrimentTypeService;

        public NutrimentTypeEffect(INutrimentTypeService nutrimentTypeService)
        {
            _nutrimentTypeService = nutrimentTypeService;
        }

        [EffectMethod(typeof(NutrimentTypeFetchhDataAction))]
        public async Task HandleNutrimentTypeFetchhDataAction(IDispatcher dispatcher)
        {
            var nutrimentTypes = await _nutrimentTypeService.GetAllNutrimentTypesAsync();

            dispatcher.Dispatch(new NutrimentTypeFetchDataResultAction(nutrimentTypes));
        }
    }
}
