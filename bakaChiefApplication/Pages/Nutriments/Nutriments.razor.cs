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
        public string TitleNutrimentModel => FormMode == FormMode.Update ? "Update nutriment" : "Create nutriment";

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
                    Dispatcher.Dispatch(new UpdateNutrimentAction(NutrimentsState.Value.Nutriment));
                    break;
                default:
                    break;
            }
        }

        private async Task RemoveNutriment(string id)
        {
            Dispatcher.Dispatch(new DeleteNutrimentAction(id));
        }

        private async Task ShowNutrimentForm(FormMode formMode, string nutrimentId = null)
        {
            FormMode = formMode;

            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new NutrimentFetchDataAction(nutrimentId));
                    break;
                default:
                    break;
            }

            Dispatcher.Dispatch(new ShowNutrimentFormAction());
        }

        private async Task CloseNutrimentForm()
        {
            Dispatcher.Dispatch(new CloseNutrimentFormAction());
        }
    }
}
