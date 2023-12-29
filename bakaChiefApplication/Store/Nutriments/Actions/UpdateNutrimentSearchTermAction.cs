namespace bakaChiefApplication.Store.Nutriments.Actions;

public class UpdateNutrimentSearchTermAction
{
    public string NutrimentSearchTerm { get; set; }

    public UpdateNutrimentSearchTermAction(string nutrimentSearchTerm)
    {
        NutrimentSearchTerm = nutrimentSearchTerm;
    }
}