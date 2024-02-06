using bakaChiefApplication.Services.BaseService;
using bakaChiefApplication.Store.BaseStore.Actions;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.BaseStore;

public class BaseEffect<T>
{
    IBaseService<T> _baseService;

    public BaseEffect(IBaseService<T> baseService)
    {
        _baseService = baseService;
    }

    [EffectMethod]
    public async Task HandleSearchByNameAction(SearchByNameAction<T> action, IDispatcher dispatcher)
    {
        var getByNameResult = await _baseService.GetByNameAsync(action.NameToSearch, take: action.Take, skip: action.Skip);

        if(!getByNameResult.IsSuccess() || getByNameResult.Value == null)
        {
            // TODO Show error
            return;
        }

        dispatcher.Dispatch(new SearchByNameResultAction<T>(getByNameResult.Value));
    }
    
    [EffectMethod]
    public async Task HandleCreateAction(CreateAction<T> action, IDispatcher dispatcher)
    {
        var createResult = await _baseService.CreateAsync(action.ItemToCreate);

        if(!createResult.IsSuccess() || createResult.Value == null)
        {
            // TODO show error message
            return;
        }

        dispatcher.Dispatch(new CreateSucceedAction<T>(createResult.Value));
    }
    
    [EffectMethod]
    public async Task HandleDeleteAction(DeleteAction<T> action, IDispatcher dispatcher)
    {
        var deleteResult = await _baseService.DeleteAsync(action.ItemIdToRemove);

        if(!deleteResult.IsSuccess() || deleteResult.Value == null)
        {
            // TODO show error message
            return;
        }

        dispatcher.Dispatch(new DeleteSucceedAction<T>(deleteResult.Value));
    }
    
    [EffectMethod]
    public async Task HandleUpdateAction(UpdateAction<T> action, IDispatcher dispatcher)
    {
        var updateResult = await _baseService.UpdateAsync(action.ItemIdToUpdate, action.ItemToUpdate);

        if(!updateResult.IsSuccess())
        {
            // TODO show error message
            return;
        }

        dispatcher.Dispatch(new UpdateSucceedAction<T>(updateResult.Value));
    }

    [EffectMethod]
    public async Task HandleSearchByIdAction(SearchByIdAction<T> action, IDispatcher dispatcher)
    {
        var getByIdResult = await _baseService.GetByIdAsync(action.ItemId);

        if(!getByIdResult.IsSuccess() || getByIdResult.Value == null)
        {
            // TODO show error
            return;
        }

        dispatcher.Dispatch(new SearchByIdResultAction<T>(getByIdResult.Value));
    }

    [EffectMethod]
    public async Task HandleSearchByNameMoreAction(SearchByNameMoreAction<T> action, IDispatcher dispatcher)
    {
        var getByNameResult = await _baseService.GetByNameAsync(action.NameToSearch, take: action.Take, skip: action.Skip);

        if(!getByNameResult.IsSuccess() || getByNameResult.Value == null)
        {
            // TODO Show error
            return;
        }

        dispatcher.Dispatch(new SearchByNameMoreResultAction<T>(getByNameResult.Value));
    }
}