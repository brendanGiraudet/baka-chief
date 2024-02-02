using bakaChiefApplication.Dtos;
using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.RecipTypesService;

public interface IRecipTypesService
{
    /// <summary>
    /// Get RecipTypes with limit
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<RecipType>> GetRecipTypesAsync();

    /// <summary>
    /// Get RecipTypes search by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<IEnumerable<RecipType>> GetRecipTypesByNameAsync(string name, int? take = null, int? skip = null);

    /// <summary>
    /// Create a RecipType
    /// </summary>
    /// <param name="recipType">RecipType info</param>
    /// <returns></returns>
    Task<MethodResult<RecipType>> CreateRecipTypeAsync(RecipType recipType);

    /// <summary>
    /// Delete specific RecipType
    /// </summary>
    /// <param name="recipTypeIdToRemove"></param>
    /// <returns></returns>
    Task<MethodResult<string>> RemoveRecipTypeAsync(string recipTypeIdToRemove);

    /// <summary>
    /// Update a RecipType
    /// </summary>
    /// <param name="recipTypeToUpdate"></param>
    /// <returns></returns>
    Task<MethodResult<RecipType>> UpdateRecipTypeAsync(RecipType recipTypeToUpdate);
}