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

        public string TitleRecip => FormMode == FormMode.Update ? "Update recip" : "Create recip";

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
            Dispatcher.Dispatch(new RemoveSelectedIngredientAction(recipIngredient));
        }

        private async Task AddSelectedIngredient(Ingredient ingredient)
        {
            RecipIngredientModel.Ingredient = ingredient;
            Dispatcher.Dispatch(new AddSelectedIngredientAction(RecipIngredientModel));
            RecipIngredientModel = new();
        }

        private async Task RemoveSelectedStep(RecipStep recipStep)
        {
            Dispatcher.Dispatch(new RemoveSelectedStepAction(recipStep));
        }

        private async Task AddSelectedStep()
        {
            Dispatcher.Dispatch(new AddSelectedStepAction(RecipStepModel));
            RecipStepModel = new();
        }

        private async Task RemoveRecip(string id)
        {
            Dispatcher.Dispatch(new DeleteRecipAction(id));
            
            NavigationManager.NavigateTo(PagesUrl.RecipsUrl);
        }
    }
}
