using bakaChiefApplication.Models;
using bakaChiefApplication.Store.NutrimentTypes;
using bakaChiefApplication.Store.NutrimentTypes.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Dispatcher = Fluxor.Dispatcher;

namespace bakaChiefApplication.Pages.NutrimentTypes
{
    public partial class NutrimentTypes
    {
        [Inject]
        public IState<NutrimentTypesState> NutrimentTypeState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        public NutrimentType Model { get; set; } = new NutrimentType();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new NutrimentTypeFetchhDataAction());
        }

        private async Task Submit()
        {
            Dispatcher.Dispatch(new AddNutrimentTypeAction(Model));
            Model = new();
        }

        private async Task RemoveNutrimentType(string id)
        {
            Dispatcher.Dispatch(new DeleteNutrimentTypeAction(id));
        }
        
        private async Task ShowNutrimentTypeForm()
        {
            Dispatcher.Dispatch(new ShowNutrimentTypeFormAction());
        }
        
        private async Task CloseNutrimentTypeForm()
        {
            Dispatcher.Dispatch(new CloseNutrimentTypeFormAction());
        }
    }
}
