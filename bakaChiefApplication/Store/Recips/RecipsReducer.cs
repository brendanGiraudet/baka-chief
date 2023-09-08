using bakaChiefApplication.Store.Recips.Actions;
using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    public static class RecipsReducer
    {
        #region RecipsFetchData
        [ReducerMethod(typeof(RecipsFetchDataAction))]
        public static RecipsState ReduceRecipsFetchData(RecipsState state) => new RecipsState(isLoading: true);

        [ReducerMethod]
        public static RecipsState ReduceRecipsFetchDataResultAction(RecipsState state, RecipsFetchDataResultAction action) => new RecipsState(isLoading: false, recips: action.Recips);
        #endregion RecipsFetchData

        #region CreateRecip
        [ReducerMethod(typeof(CreateRecipAction))]
        public static RecipsState ReduceCreateRecipAction(RecipsState state) => new RecipsState(isLoading: true, recips: state.Recips, isRecipFormHidden: false);

        [ReducerMethod]
        public static RecipsState ReduceCreateRecipResultAction(RecipsState state, CreateRecipResultAction action) => new RecipsState(isLoading: false, recips: state.Recips.Append(action.Recip), isRecipFormHidden: true);
        #endregion CreateRecip

        #region DeleteRecip
        [ReducerMethod(typeof(DeleteRecipAction))]
        public static RecipsState ReduceDeleteRecipAction(RecipsState state) => new RecipsState(isLoading: true, recips: state.Recips);

        [ReducerMethod]
        public static RecipsState ReduceDeleteRecipResultAction(RecipsState state, DeleteRecipResultAction action) => new RecipsState(isLoading: false, recips: state.Recips.Where(r => r.Id != action.RecipId));
        #endregion DeleteRecip

        #region RecipFetchData
        [ReducerMethod(typeof(RecipFetchDataAction))]
        public static RecipsState ReduceRecipFetchDataAction(RecipsState state) => new RecipsState(isLoading: true);

        [ReducerMethod]
        public static RecipsState ReduceRecipFetchDataResulAction(RecipsState state, RecipFetchDataResulAction action) => new RecipsState(isLoading: false, recips: state.Recips, recip:action.Recip);
        #endregion RecipsFetchData

        #region UpdateRecip
        [ReducerMethod(typeof(UpdateRecipAction))]
        public static RecipsState ReduceUpdateRecipAction(RecipsState state) => new RecipsState(isLoading: true, recips: state.Recips);

        [ReducerMethod]
        public static RecipsState ReduceUpdateRecipResultAction(RecipsState state, UpdateRecipResultAction action)
        {
            var recips = state.Recips.Where(r => r.Id != action.Recip.Id);
            recips = recips.Append(action.Recip);

            return new RecipsState(isLoading: false, recips: recips);
        }
        #endregion UpdateRecip

        //[ReducerMethod]
        //public static RecipsState ReduceAddSelectedStepAction(RecipsState state, AddSelectedStepAction action) => new RecipsState(recips: state.Recips, selectedIngredients: state.SelectedRecipIngredients, isRecipFormHidden: false, selectedRecipSteps: state.SelectedRecipSteps.Append(action.RecipStep));

        //[ReducerMethod]
        //public static RecipsState ReduceRemoveSelectedStepAction(RecipsState state, RemoveSelectedStepAction action) => new RecipsState(recips: state.Recips, selectedIngredients: state.SelectedRecipIngredients, isRecipFormHidden: false, selectedRecipSteps: state.SelectedRecipSteps.Where(s => s.Id != action.RecipStep.Id));

        //[ReducerMethod]
        //public static RecipsState ReduceAddSelectedIngredientAction(RecipsState state, AddSelectedIngredientAction action) => new RecipsState(recips: state.Recips, selectedIngredients: state.SelectedRecipIngredients.Append(action.RecipIngredient), isRecipFormHidden: false);

        //[ReducerMethod]
        //public static RecipsState ReduceRemoveSelectedIngredientAction(RecipsState state, RemoveSelectedIngredientAction action) => new RecipsState(recips: state.Recips, selectedIngredients: state.SelectedRecipIngredients.Where(s => s.Id != action.RecipIngredient.Id), isRecipFormHidden: false);
    }
}
