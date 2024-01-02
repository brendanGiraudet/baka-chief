using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Nutriments.Actions;

public class UpdateNutrimentSucceedAction
{
    public Nutriment UpdatedNutriment { get; set; }

    public UpdateNutrimentSucceedAction(Nutriment updatedNutriment)
    {
        UpdatedNutriment = updatedNutriment;
    }
}