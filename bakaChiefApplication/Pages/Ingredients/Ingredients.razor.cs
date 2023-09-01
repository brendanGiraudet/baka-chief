using bakaChiefApplication.Models;
using bakaChiefApplication.Pages.NutrimentTypes;
using bakaChiefApplication.Store.Ingredients;
using bakaChiefApplication.Store.Ingredients.Actions;
using bakaChiefApplication.Store.NutrimentTypes;
using bakaChiefApplication.Store.NutrimentTypes.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Pages.Ingredients
{
    public partial class Ingredients
    {
        [Inject]
        public IState<IngredientsState> IngredientState { get; set; }
        
        [Inject]
        public IState<NutrimentTypesState> NutrimentTypeState { get; set; }

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
            Model = new();
        }
        
        private async Task RemoveNutrimentType(NutrimentType nutrimentType)
        {
            Dispatcher.Dispatch(new RemoveSelectedNutrimentAction(nutrimentType));

            Model.NutrimentTypes.Remove(nutrimentType);
        }
        
        private async Task AddNutrimentType(NutrimentType nutrimentType)
        {
            Dispatcher.Dispatch(new AddSelectedNutrimentAction(nutrimentType));

            Model.NutrimentTypes.Add(nutrimentType);
        }

        private async Task RemoveIngredient(string id)
        {
            Dispatcher.Dispatch(new DeleteIngredientAction(id));
        }
    }
}
