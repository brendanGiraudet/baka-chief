using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.NutrimentTypeService
{
    public interface INutrimentTypeService
    {
        Task<List<NutrimentType>> GetAllNutrimentTypesAsync();
        Task<NutrimentType> GetNutrimentTypeByIdAsync(string id);
        Task<NutrimentType> CreateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task DeleteNutrimentTypeAsync(string id);
    }
}
