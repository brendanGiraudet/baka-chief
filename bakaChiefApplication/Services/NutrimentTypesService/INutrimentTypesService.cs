using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.NutrimentTypesService
{
    public interface INutrimentTypesService
    {
        Task<IEnumerable<NutrimentType>> GetAllNutrimentTypesAsync();
        Task<NutrimentType> GetNutrimentTypeByIdAsync(string id);
        Task<NutrimentType> CreateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task DeleteNutrimentTypeAsync(string id);
    }
}
