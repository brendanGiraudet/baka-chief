using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.NutrimentsService;

public interface INutrimentsService
{
    /// <summary>
    /// Get Nutriments with limit
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Nutriment>> GetNutrimentsAsync();
    
    /// <summary>
    /// Get Nutriments search by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<IEnumerable<Nutriment>> GetNutrimentsByNameAsync(string name);
}