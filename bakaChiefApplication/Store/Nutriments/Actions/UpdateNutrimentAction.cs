using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Nutriments.Actions;

public class UpdateNutrimentAction
{
    public Models.Nutriment NutrimentToUpdate { get; set; }

    public UpdateNutrimentAction(Nutriment nutrimentToUpdate)
    {
        NutrimentToUpdate = nutrimentToUpdate;
    }
}