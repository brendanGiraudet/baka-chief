using bakaChiefApplication.Store.ProductInfos;
using bakaChiefApplication.Store.ProductInfos.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.ProductInfos;

public partial class ProductInfos
{
    [Inject] public IState<ProductInfosState> ProductInfosState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private string searchTerm;

    private void UpdateProductInfoSearchTerm(string name)
    {
        Dispatcher.Dispatch(new ProductInfoSearchByNameFetchDataAction(name));
        Dispatcher.Dispatch(new UpdateProductInfoSearchTermAction(name));
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        searchTerm = ProductInfosState.Value.ProductInfoSearchTerm;
        Dispatcher.Dispatch(new ProductInfoSearchByNameFetchDataAction(ProductInfosState.Value.ProductInfoSearchTerm));
    }
}
