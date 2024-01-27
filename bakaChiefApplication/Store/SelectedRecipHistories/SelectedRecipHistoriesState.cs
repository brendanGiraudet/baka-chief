using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.SelectedRecipHistories
{
    [FeatureState]
    public class SelectedRecipHistoriesState
    {
        public bool IsLoading { get; }

        public IEnumerable<SelectedRecipHistory> SelectedRecipHistories { get; }
        
        public SelectedRecipHistory SelectedRecipHistory { get; }

        public bool? NeedToReload { get; }

        private SelectedRecipHistoriesState()
        {
            IsLoading = false;
            SelectedRecipHistories = Enumerable.Empty<SelectedRecipHistory>();
            SelectedRecipHistory = new();
        }

        public SelectedRecipHistoriesState(SelectedRecipHistoriesState? currentState = null,  bool? isLoading = null, IEnumerable<SelectedRecipHistory>? selectedRecipHistories = null, SelectedRecipHistory? selectedRecipHistory = null, bool? needToReload = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            SelectedRecipHistories = selectedRecipHistories != null ? selectedRecipHistories : currentState != null ? currentState.SelectedRecipHistories : Enumerable.Empty<SelectedRecipHistory>();
            
            SelectedRecipHistory = selectedRecipHistory != null ? selectedRecipHistory : currentState != null ? currentState.SelectedRecipHistory : new();
            
            NeedToReload = needToReload != null ? needToReload : currentState != null ? currentState.NeedToReload : true;
        }
    }
}
