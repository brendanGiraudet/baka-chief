using bakaChiefApplication.Constants;
using bakaChiefApplication.Enums;
using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Recips
{
    public partial class RecipForm
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<RecipsState> RecipsState { get; set; }
        
        [Inject] public IState<IngredientsState> IngredientState { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public string Action { get; set; }

        [Parameter] public string? RecipId { get; set; }

        public RecipIngredient RecipIngredientModel { get; set; } = new();

        public RecipStep RecipStepModel { get; set; } = new();

        public FormMode FormMode => (FormMode)Enum.Parse(typeof(FormMode), Action);

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new IngredientsFetchDataAction());

            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new RecipFetchDataAction(RecipId));
                    break;
            }
        }

        private async Task SaveRecip()
        {
            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new UpdateRecipAction(RecipsState.Value.Recip));
                    break;
                case FormMode.Creation:
                    Dispatcher.Dispatch(new CreateRecipAction(RecipsState.Value.Recip));
                    break;
                default:
                    break;
            }

            NavigationManager.NavigateTo(PagesUrl.RecipsUrl);
        }

        private async Task RemoveSelectedIngredient(RecipIngredient recipIngredient)
        {
            RecipsState.Value.Recip.RecipIngredients = RecipsState.Value.Recip.RecipIngredients.Where(r => r.Id != recipIngredient.Id);
        }

        private async Task AddSelectedIngredient(Ingredient ingredient)
        {
            RecipIngredientModel.Ingredient = ingredient;
            RecipsState.Value.Recip.RecipIngredients = RecipsState.Value.Recip.RecipIngredients.Append(RecipIngredientModel);
            RecipIngredientModel = new();
        }

        private async Task RemoveSelectedStep(RecipStep recipStep)
        {
            RecipsState.Value.Recip.RecipSteps = RecipsState.Value.Recip.RecipSteps.Where(r => r.Id != recipStep.Id);
        }

        private async Task AddSelectedStep()
        {
            RecipsState.Value.Recip.RecipSteps = RecipsState.Value.Recip.RecipSteps.Append(RecipStepModel);
            RecipStepModel = new();
        }
    }
}
