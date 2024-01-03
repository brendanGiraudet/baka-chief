using bakaChiefApplication.Models;
using Fluxor;

namespace bakaChiefApplication.Store.Recips
{
    [FeatureState]
    public class RecipsState
    {
        public bool IsLoading { get; }

        public IEnumerable<Recip> Recips { get; }
        
        public Recip Recip { get; }

        public string? RecipSearchTerm { get; }
        
        public bool? NeedToReload { get; }

        private RecipsState()
        {
            IsLoading = false;
            Recips = Enumerable.Empty<Recip>();
            Recip = new();
        }

        public RecipsState(RecipsState? currentState = null,  bool? isLoading = null, IEnumerable<Recip>? recips = null, string? recipSearchTerm = null, Recip? recip = null, bool? needToReload = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            Recips = recips != null ? recips : currentState != null ? currentState.Recips : Enumerable.Empty<Recip>();
            
            RecipSearchTerm = recipSearchTerm != null ? recipSearchTerm : currentState != null ? currentState.RecipSearchTerm : null;
            
            Recip = recip != null ? recip : currentState != null ? currentState.Recip : new();
            
            NeedToReload = needToReload != null ? needToReload : currentState != null ? currentState.NeedToReload : true;
        }
    }
}
