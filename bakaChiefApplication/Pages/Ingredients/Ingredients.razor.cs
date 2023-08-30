using bakaChiefApplication.Models;
using bakaChiefApplication.Store.Ingredient;
using bakaChiefApplication.Store.Ingredient.Actions;
using bakaChiefApplication.Store.NutrimentType;
using bakaChiefApplication.Store.NutrimentType.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Ingredients
{
    public partial class Ingredients
    {
        [Inject]
        public IState<IngredientState> IngredientState { get; set; }
        
        [Inject]
        public IState<NutrimentTypeState> NutrimentTypeState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        public Ingredient Model { get; set; } = new Ingredient();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new IngredientFetchDataAction());
        }

        private async Task ShowNutrimentTypeForm()
        {
            Dispatcher.Dispatch(new ShowIngredientFormAction());
            Dispatcher.Dispatch(new NutrimentTypeFetchhDataAction());
        }

        private async Task CloseNutrimentTypeForm()
        {
            Dispatcher.Dispatch(new CloseIngredientFormAction());
        }

        private async Task Submit()
        {
            Dispatcher.Dispatch(new AddIngredientAction(Model));
        }
        
        private async Task RemoveNutrimentType(NutrimentType nutrimentType)
        {
            Dispatcher.Dispatch(new RemoveSelectedNutrimentAction(nutrimentType));
        }
        
        private async Task AddNutrimentType(NutrimentType nutrimentType)
        {
            Dispatcher.Dispatch(new AddSelectedNutrimentAction(nutrimentType));
        }
    }
}
