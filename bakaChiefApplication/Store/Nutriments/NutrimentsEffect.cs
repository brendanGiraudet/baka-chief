using bakaChiefApplication.Services.NutrimentsService;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Nutriments
{
    public class NutrimentsEffect
    {
        readonly INutrimentsService _nutrimentTypeService;

        public NutrimentsEffect(INutrimentsService nutrimentTypeService)
        {
            _nutrimentTypeService = nutrimentTypeService;
        }

        [EffectMethod(typeof(NutrimentsFetchDataAction))]
        public async Task HandleNutrimentFetchhDataAction(IDispatcher dispatcher)
        {
            var nutriments = await _nutrimentTypeService.GetNutrimentsAsync();

            dispatcher.Dispatch(new NutrimentsFetchDataResultAction(nutriments));
        }
        
        [EffectMethod]
        public async Task HandleCreationNutrimentAction(CreateNutrimentAction action, IDispatcher dispatcher)
        {
            var nutriment = await _nutrimentTypeService.CreateNutrimentAsync(action.NutrimentType);

            dispatcher.Dispatch(new CreateNutrimentResultAction(nutriment));
        }
        
        [EffectMethod]
        public async Task HandleDeleteNutrimentAction(DeleteNutrimentAction action, IDispatcher dispatcher)
        {
            await _nutrimentTypeService.DeleteNutrimentAsync(action.NutrimentId);

            dispatcher.Dispatch(new DeleteNutrimentResultAction(action.NutrimentId));
        }
    }
}
