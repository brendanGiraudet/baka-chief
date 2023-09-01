using bakaChiefApplication.Services.RecipsService;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    public class RecipsEffect
    {
        readonly IRecipsService _recipsService;

        public RecipsEffect(IRecipsService recipsService)
        {
            _recipsService = recipsService;
        }

        [EffectMethod(typeof(RecipFetchDataAction))]
        public async Task HandleRecipFetchDataAction(IDispatcher dispatcher)
        {
            var recips = await _recipsService.GetAllRecipsAsync();

            dispatcher.Dispatch(new RecipFetchDataResultAction(recips));
        }

        [EffectMethod]
        public async Task HandleAddRecipAction(AddRecipAction action, IDispatcher dispatcher)
        {
            var recip = await _recipsService.CreateRecipAsync(action.Recip);

            dispatcher.Dispatch(new AddRecipResultAction(recip));
        }

        [EffectMethod]
        public async Task HandleDeleteRecipAction(DeleteRecipAction action, IDispatcher dispatcher)
        {
            await _recipsService.DeleteRecipAsync(action.RecipId);

            dispatcher.Dispatch(new DeleteRecipResultAction(action.RecipId));
        }
    }
}
