using bakaChiefApplication.Store.ProductInfos;
using bakaChiefApplication.Store.ProductInfos.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.ProductInfoDetails;

public partial class ProductInfoDetails
{
    [Inject] public IState<ProductInfosState> ProductInfosState { get; set; }

    [Inject] public IDispatcher Dispatcher { get; set; }

    [Parameter] public string Code { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Dispatcher.Dispatch(new ProductInfoDetailsFetchDataAction(Code));
    }
}
