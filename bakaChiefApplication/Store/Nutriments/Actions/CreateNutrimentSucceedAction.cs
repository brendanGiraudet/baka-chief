using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Nutriments.Actions;

public class CreateNutrimentSucceedAction
{
    public Nutriment CreatedNutriment { get; set; }

    public CreateNutrimentSucceedAction(Nutriment createdNutriment)
    {
        CreatedNutriment = createdNutriment;
    }
}