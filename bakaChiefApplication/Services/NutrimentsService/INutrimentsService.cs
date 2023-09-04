using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.NutrimentsService
{
    public interface INutrimentsService
    {
        Task<IEnumerable<Nutriment>> GetNutrimentsAsync();
        Task<Nutriment> GetNutrimentByIdAsync(string id);
        Task<Nutriment> CreateNutrimentAsync(Nutriment nutrimentType);
        Task UpdateNutrimentAsync(Nutriment nutrimentType);
        Task DeleteNutrimentAsync(string id);
    }
}
