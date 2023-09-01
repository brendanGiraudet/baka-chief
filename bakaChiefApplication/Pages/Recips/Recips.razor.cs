using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.Recips;
using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Recips
{
    public partial class Recips
    {
        [Inject]
        public IState<RecipsState> RecipsState { get; set; }

        [Inject]
        public IState<IngredientsState> IngredientState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        public Recip Model { get; set; } = new Recip();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new RecipFetchDataAction());
        }

        private async Task ShowRecipForm()
        {
            Dispatcher.Dispatch(new ShowRecipFormAction());
            Dispatcher.Dispatch(new IngredientFetchDataAction());
        }

        private async Task CloseRecipForm()
        {
            Dispatcher.Dispatch(new CloseRecipFormAction());
        }

        private async Task Submit()
        {
            Dispatcher.Dispatch(new AddRecipAction(Model));
            Model = new();
        }

        private async Task RemoveSelectedIngredient(Ingredient ingredient)
        {
            Dispatcher.Dispatch(new RemoveSelectedIngredientAction(ingredient));

            Model.RecipIngredients = Model.RecipIngredients.Where(r => r.Ingredient.Id == ingredient.Id).ToArray();
        }

        private async Task AddSelectedIngredient(Ingredient ingredient, string measureUnit, int quantity)
        {
            Dispatcher.Dispatch(new AddSelectedIngredientAction(ingredient));

            Model.RecipIngredients = Model.RecipIngredients.Append(new RecipIngredient
            {
                Ingredient = ingredient,
                MeasureUnit = measureUnit,
                Quantity = quantity,
            });
        }

        private async Task RemoveRecip(string id)
        {
            Dispatcher.Dispatch(new DeleteRecipAction(id));
        }
    }
}
