using bakaChiefApplication.Store.ProductInfos;
using bakaChiefApplication.Store.ProductInfos.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.ProductInfos;

public partial class ProductInfos
{
    [Inject] public IState<ProductInfosState> ProductInfosState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Dispatcher.Dispatch(new ProductInfosFetchDataAction());
    }
}
