using bakaChiefApplication.Models;

namespace bakaChiefApplication.Extensions;

public static class RecipExtension
{
    public static Recip Format(this Recip recip)
    {
        recip.Name = recip.Name.ToLower();
        
        return recip;
    }
}