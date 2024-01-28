using bakaChiefApplication.Models;

namespace bakaChiefApplication.Extensions;

public static class NutrimentExtension
{
    public static Nutriment Format(this Nutriment nutriment)
    {
        nutriment.Name = nutriment.Name.ToLower();
        
        return nutriment;
    }
}