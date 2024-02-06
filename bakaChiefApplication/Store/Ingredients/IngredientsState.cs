using bakaChiefApplication.Models;
using bakaChiefApplication.Store.BaseStore;
using Fluxor;

namespace bakaChiefApplication.Store.Ingredients;

[FeatureState]
public class IngredientsState : BaseState<Ingredient>
{
    private IngredientsState() : base()
    {

    }
    public IngredientsState(IngredientsState? currentState = null, bool? isLoading = null, IEnumerable<Ingredient>? items = null, string? nameToSearch = null, Ingredient? item = null, bool? needToReload = null) : base(currentState, isLoading, items, nameToSearch, item, needToReload)
    {

    }
}