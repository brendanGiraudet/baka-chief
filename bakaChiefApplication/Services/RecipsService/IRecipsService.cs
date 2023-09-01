using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.RecipsService
{
    public interface IRecipsService
    {
        Task<IEnumerable<Recip>> GetAllRecipsAsync();
        Task<Recip> GetRecipByIdAsync(string id);
        Task<Recip> CreateRecipAsync(Recip recip);
        Task UpdateRecipAsync(Recip recip);
        Task DeleteRecipAsync(string id);
    }
}
