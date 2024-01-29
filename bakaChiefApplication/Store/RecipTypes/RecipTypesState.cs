using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.RecipTypes
{
    [FeatureState]
    public class RecipTypesState
    {
        public bool IsLoading { get; }

        public IEnumerable<RecipType> RecipTypes { get; }
        
        public RecipType RecipType { get; }

        public string? RecipTypeSearchTerm { get; }

        public bool? NeedToReload { get; }

        private RecipTypesState()
        {
            IsLoading = false;
            RecipTypes = Enumerable.Empty<RecipType>();
            RecipType = new();
        }

        public RecipTypesState(RecipTypesState? currentState = null,  bool? isLoading = null, IEnumerable<RecipType>? recipTypes = null, string? recipTypesearchTerm = null, RecipType? recipType = null, bool? needToReload = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            RecipTypes = recipTypes != null ? recipTypes : currentState != null ? currentState.RecipTypes : Enumerable.Empty<RecipType>();
            
            RecipTypeSearchTerm = recipTypesearchTerm != null ? recipTypesearchTerm : currentState != null ? currentState.RecipTypeSearchTerm : null;
            
            RecipType = recipType != null ? recipType : currentState != null ? currentState.RecipType : new();

            NeedToReload = needToReload != null ? needToReload : currentState != null ? currentState.NeedToReload : true;
        }
    }
}
