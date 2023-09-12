using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Nutriments;
using bakaChiefApplication.Store.Nutriments.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Ingredients
{
    public partial class Ingredients
    {
        [Inject] public IState<IngredientsState> IngredientState { get; set; }

        [Inject] public IState<NutrimentsState> NutrimentsState { get; set; }

        [Inject] public IDispatcher Dispatcher { get; set; }

        public FormMode FormMode { get; set; } = FormMode.Creation;
        public string TitleIngredientModal => FormMode == FormMode.Update ? "Update ingredient" : "Create ingredient";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new IngredientsFetchDataAction());
        }

        private async Task ShowIngredientForm(FormMode formMode, string ingredientId = null)
        {
            FormMode = formMode;

            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new IngredientFetchDataAction(ingredientId));
                    break;
                default:
                    break;
            }

            Dispatcher.Dispatch(new ShowIngredientFormAction());
            Dispatcher.Dispatch(new NutrimentsFetchDataAction());
        }

        private async Task CloseIngredientForm()
        {
            Dispatcher.Dispatch(new CloseIngredientFormAction());
        }

        private async Task RemoveSelectedNutriment(Nutriment nutrimentType)
        {
            Dispatcher.Dispatch(new RemoveSelectedNutrimentAction(nutrimentType));
        }

        private async Task AddSelectedNutriment(Nutriment nutrimentType)
        {
            Dispatcher.Dispatch(new AddSelectedNutrimentAction(nutrimentType));
        }

        private async Task RemoveIngredient(string id)
        {
            Dispatcher.Dispatch(new DeleteIngredientAction(id));
        }

        private async Task SaveIngredient()
        {
            switch (FormMode)
            {
                case FormMode.Creation:
                    Dispatcher.Dispatch(new CreateIngredientAction(IngredientState.Value.Ingredient));
                    break;
                case FormMode.Update:
                    Dispatcher.Dispatch(new UpdateIngredientAction(IngredientState.Value.Ingredient));
                    break;
                default:
                    break;
            }
        }
    }
}
