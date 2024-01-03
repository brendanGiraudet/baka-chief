using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.RecipsService;

public interface IRecipsService
{
    /// <summary>
    /// Get Recips with limit
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Recip>> GetRecipsAsync();

    /// <summary>
    /// Get Recips search by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<IEnumerable<Recip>> GetRecipsByNameAsync(string name);

    /// <summary>
    /// Create a Recip
    /// </summary>
    /// <param name="Recip">Recip info</param>
    /// <returns></returns>
    Task<MethodResult<Recip>> CreateRecipAsync(Recip Recip);
    
    /// <summary>
    /// Delete specific Recip
    /// </summary>
    /// <param name="RecipIdToRemove"></param>
    /// <returns></returns>
    Task<MethodResult<string>> RemoveRecipAsync(string RecipIdToRemove);
    
    /// <summary>
    /// Update an Recip
    /// </summary>
    /// <param name="RecipToUpdate"></param>
    /// <returns></returns>
    Task<MethodResult<Recip>>UpdateRecipAsync(Recip RecipToUpdate);
}