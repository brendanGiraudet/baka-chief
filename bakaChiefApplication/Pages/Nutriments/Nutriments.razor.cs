using bakaChiefApplication.Enums;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Dispatcher = Fluxor.Dispatcher;

namespace bakaChiefApplication.Pages.Nutriments
{
    public partial class Nutriments
    {
        [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

        [Inject] public IDispatcher Dispatcher { get; set; }

        public FormMode FormMode { get; set; } = FormMode.Creation;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new NutrimentsFetchDataAction());
        }

        private async Task SaveNutriment()
        {
            switch (FormMode)
            {
                case FormMode.Creation:
                    Dispatcher.Dispatch(new CreateNutrimentAction(NutrimentsState.Value.Nutriment));
                    break;
                case FormMode.Update:
                    //Dispatcher.Dispatch(new AddNutrimentTypeAction(Model));
                    break;
                default:
                    break;
            }
        }

        private async Task RemoveNutrimentType(string id)
        {
            Dispatcher.Dispatch(new DeleteNutrimentAction(id));
        }

        private async Task ShowNutrimentForm(FormMode formMode)
        {
            FormMode = formMode;

            Dispatcher.Dispatch(new ShowNutrimentFormAction());
        }

        private async Task CloseNutrimentForm()
        {
            Dispatcher.Dispatch(new CloseNutrimentFormAction());
        }
    }
}
