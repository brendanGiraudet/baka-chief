using bakaChiefApplication.Store.NutrimentType;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Dispatcher = Fluxor.Dispatcher;

namespace bakaChiefApplication.Pages.NutrimentTypes
{
    public partial class NutrimentTypes
    {
        [Inject]
        public IState<NutrimentTypeState> NutrimentTypeState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        private int currentCount => NutrimentTypeState.Value.Count;

        private void IncrementCount()
        {
            Dispatcher.Dispatch(new AddNutrimentTypeAction());
        }
    }
}
