using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.SelectedRecipHistoriesService;

public interface ISelectedRecipHistoriesService
{
    /// <summary>
    /// Get the 10 newest selected recips history
    /// </summary>
    /// <returns></returns>
    Task<MethodResult<IEnumerable<SelectedRecipHistory>>> GetSelectedRecipHistoriesAsync();

    /// <summary>
    /// Generate a selected recips history
    /// </summary>
    /// <returns></returns>
    Task<MethodResult<SelectedRecipHistory>> GenerateSelectedRecipHistoriesAsync();

    /// <summary>
    /// Get selected recip hitory by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<MethodResult<SelectedRecipHistory>> GetSelectedRecipHistoryByIdAsync(string id);
}