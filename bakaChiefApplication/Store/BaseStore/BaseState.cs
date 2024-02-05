using Fluxor;

namespace bakaChiefApplication.Store.BaseStore
{
    [FeatureState]
    public class BaseState<T>
    {
        public bool IsLoading { get; }

        public IEnumerable<T> Items { get; }
        
        public T Item { get; }

        public string? NameToSearch { get; }

        public bool? NeedToReload { get; }

        private BaseState()
        {
            IsLoading = false;
            Items = Enumerable.Empty<T>();
            Item = Activator.CreateInstance<T>();
        }

        public BaseState(BaseState<T>? currentState = null,  bool? isLoading = null, IEnumerable<T>? items = null, string? nameToSearch = null, object? item = null, bool? needToReload = null)
        {
            IsLoading = isLoading != null ? isLoading.Value : currentState != null ? currentState.IsLoading : false;
            
            Items = items != null ? items : currentState != null ? currentState.Items : Enumerable.Empty<T>();
            
            NameToSearch = nameToSearch != null ? nameToSearch : currentState != null ? currentState.NameToSearch : null;
            
            Item = item != null ? (T)item : currentState != null ? currentState.Item : Activator.CreateInstance<T>();

            NeedToReload = needToReload != null ? needToReload : currentState != null ? currentState.NeedToReload : true;
        }
    }
}
