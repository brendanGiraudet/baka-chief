using bakaChiefApplication.Services.NutrimentTypeService;
using bakaChiefApplication.Store.NutrimentType.Actions;
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
        
        [EffectMethod]
        public async Task HandleAddNutrimentTypeAction(AddNutrimentTypeAction action, IDispatcher dispatcher)
        {
            var nutrimentType = await _nutrimentTypeService.CreateNutrimentTypeAsync(action.NutrimentType);

            dispatcher.Dispatch(new AddNutrimentTypeResultAction(nutrimentType));
        }
        
        [EffectMethod]
        public async Task HandleDeleteNutrimentTypeAction(DeleteNutrimentTypeAction action, IDispatcher dispatcher)
        {
            await _nutrimentTypeService.DeleteNutrimentTypeAsync(action.NutrimentTypeId);

            dispatcher.Dispatch(new DeleteNutrimentTypeResultAction(action.NutrimentTypeId));
        }
    }
}
