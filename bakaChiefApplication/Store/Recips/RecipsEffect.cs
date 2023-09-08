using bakaChiefApplication.Services.RecipsService;
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

        [EffectMethod(typeof(RecipsFetchDataAction))]
        public async Task HandleRecipFetchDataAction(IDispatcher dispatcher)
        {
            var recips = await _recipsService.GetAllRecipsAsync();

            dispatcher.Dispatch(new RecipsFetchDataResultAction(recips));
        }

        [EffectMethod]
        public async Task HandleCreateRecipAction(CreateRecipAction action, IDispatcher dispatcher)
        {
            var recip = await _recipsService.CreateRecipAsync(action.Recip);

            dispatcher.Dispatch(new CreateRecipResultAction(recip));
        }

        [EffectMethod]
        public async Task HandleDeleteRecipAction(DeleteRecipAction action, IDispatcher dispatcher)
        {
            await _recipsService.DeleteRecipAsync(action.RecipId);

            dispatcher.Dispatch(new DeleteRecipResultAction(action.RecipId));
        }
        
        [EffectMethod]
        public async Task HandleRecipFetchDataAction(RecipFetchDataAction action, IDispatcher dispatcher)
        {
            var recip = await _recipsService.GetRecipByIdAsync(action.RecipId);

            dispatcher.Dispatch(new RecipFetchDataResulAction(recip));
        }
        
        [EffectMethod]
        public async Task HandleUpdateRecipAction(UpdateRecipAction action, IDispatcher dispatcher)
        {
            await _recipsService.UpdateRecipAsync(action.Recip);

            dispatcher.Dispatch(new UpdateRecipResultAction(action.Recip));
        }
    }
}