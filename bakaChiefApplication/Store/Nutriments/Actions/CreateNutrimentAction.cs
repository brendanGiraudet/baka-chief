using bakaChiefApplication.Models;

namespace bakaChiefApplication.Store.Nutriments.Actions;

public class CreateNutrimentAction
{
    public Nutriment NutrimentToCreate { get; set; }

    public CreateNutrimentAction(Nutriment nutrimentToCreate)
    {
        NutrimentToCreate = nutrimentToCreate;
    }
}