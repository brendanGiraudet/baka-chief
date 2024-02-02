namespace bakaChiefApplication.Store.Nutriments.Actions;

public class NutrimentSearchByIdResultAction
{
    public Models.Nutriment Nutriment { get; }

    public NutrimentSearchByIdResultAction(Models.Nutriment nutriment)
    {
        Nutriment = nutriment;
    }
}