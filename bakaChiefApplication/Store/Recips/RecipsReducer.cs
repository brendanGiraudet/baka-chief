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
        public static RecipsState ReduceCreateRecipAction(RecipsState state) => new RecipsState(isLoading: true, recips: state.Recips);

        [ReducerMethod]
        public static RecipsState ReduceCreateRecipResultAction(RecipsState state, CreateRecipResultAction action) => new RecipsState(isLoading: false, recips: state.Recips.Append(action.Recip));
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

        #region SelectedStep
        [ReducerMethod]
        public static RecipsState ReduceAddSelectedStepAction(RecipsState state, AddSelectedStepAction action)
        {
            state.Recip.RecipSteps = state.Recip.RecipSteps.Append(action.RecipStep).ToArray();

            return new RecipsState(recips: state.Recips, recip:state.Recip);
        }

        [ReducerMethod]
        public static RecipsState ReduceRemoveSelectedStepAction(RecipsState state, RemoveSelectedStepAction action)
        {
            state.Recip.RecipSteps = state.Recip.RecipSteps.Where(s => s.Id != action.RecipStep.Id).ToArray();

            return new RecipsState(recips: state.Recips, recip: state.Recip);
        }
        #endregion SelectedStep

        #region SelectedIngredient
        [ReducerMethod]
        public static RecipsState ReduceAddSelectedIngredientAction(RecipsState state, AddSelectedProductInfoAction action)
        {
            state.Recip.RecipProductInfos = state.Recip.RecipProductInfos.Append(action.RecipProductInfo).ToArray();

            return new RecipsState(recips: state.Recips, recip: state.Recip);
        }

        [ReducerMethod]
        public static RecipsState ReduceRemoveSelectedIngredientAction(RecipsState state, RemoveSelectedProductInfoAction action)
        {
            state.Recip.RecipProductInfos = state.Recip.RecipProductInfos.Where(i => i.Id != action.RecipProductInfo.Id).ToArray();

            return new RecipsState(recips: state.Recips, recip: state.Recip);
        }
        #endregion SelectedIngredient
    }
}
