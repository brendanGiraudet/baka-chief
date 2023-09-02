using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    public static class RecipsReducer
    {
        [ReducerMethod(typeof(RecipFetchDataAction))]
        public static RecipsState ReduceIngredientFetchDataAction(RecipsState state) => new RecipsState(isLoading: true);

        [ReducerMethod]
        public static RecipsState ReduceIngredientFetchDataAction(RecipsState state, RecipFetchDataResultAction action) => new RecipsState(isLoading: false, recips: action.Recips);

        [ReducerMethod(typeof(ShowRecipFormAction))]
        public static RecipsState ReduceShowRecipFormAction(RecipsState state) => new RecipsState(recips: state.Recips, isRecipFormHidden: false);

        [ReducerMethod(typeof(CloseRecipFormAction))]
        public static RecipsState ReduceCloseRecipFormAction(RecipsState state) => new RecipsState(recips: state.Recips, isRecipFormHidden: true);

        [ReducerMethod]
        public static RecipsState ReduceAddSelectedIngredientAction(RecipsState state, AddSelectedIngredientAction action) => new RecipsState(recips: state.Recips, selectedIngredients: state.SelectedRecipIngredients.Append(action.RecipIngredient), isRecipFormHidden: false);

        [ReducerMethod]
        public static RecipsState ReduceRemoveSelectedIngredientAction(RecipsState state, RemoveSelectedIngredientAction action) => new RecipsState(recips: state.Recips, selectedIngredients: state.SelectedRecipIngredients.Where(s => s.Id != action.RecipIngredient.Id), isRecipFormHidden: false);

        [ReducerMethod(typeof(AddRecipAction))]
        public static RecipsState ReduceAddRecipAction(RecipsState state) => new RecipsState(isLoading: true, recips: state.Recips, isRecipFormHidden: false);

        [ReducerMethod]
        public static RecipsState ReduceAddRecipResultAction(RecipsState state, AddRecipResultAction action) => new RecipsState(isLoading: false, recips: state.Recips.Append(action.Recip), isRecipFormHidden: true);

        [ReducerMethod(typeof(DeleteRecipAction))]
        public static RecipsState ReduceDeleteRecipAction(RecipsState state) => new RecipsState(isLoading: true, recips: state.Recips);

        [ReducerMethod]
        public static RecipsState ReduceDeleteRecipResultAction(RecipsState state, DeleteRecipResultAction action) => new RecipsState(isLoading: false, recips: state.Recips.Where(r => r.Id != action.RecipId));
    }
}
