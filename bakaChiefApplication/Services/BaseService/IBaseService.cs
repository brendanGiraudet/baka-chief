using bakaChiefApplication.Dtos;

namespace bakaChiefApplication.Services.BaseService;

public interface IBaseService<T>
{
    /// <summary>
    /// Get items by name
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <param name="take">How many take item number</param>
    /// <param name="skip">How many skip item number</param>
    /// <returns></returns>
    Task<MethodResult<IEnumerable<T>>> GetByNameAsync(string name, int? take = null, int? skip = null);

    /// <summary>
    /// Get item by id
    /// </summary>
    /// <param name="id">Id of the specific item</param>
    /// <returns></returns>
    Task<MethodResult<T>> GetByIdAsync(string id);

    /// <summary>
    /// Create an item
    /// </summary>
    /// <param name="item">Item 's info</param>
    /// <returns></returns>
    Task<MethodResult<T>> CreateAsync(T item);

    /// <summary>
    /// Delete an item
    /// </summary>
    /// <param name="itemIdToDelete">Id of the deleted item</param>
    /// <returns></returns>
    Task<MethodResult<string>> DeleteAsync(string itemIdToDelete);

    /// <summary>
    /// Update an item
    /// </summary>
    /// <param name="id">Id of the specific item</param>
    /// <param name="itemToUpdate">Item's info</param>
    /// <returns></returns>
    Task<MethodResult<T>> UpdateAsync(string id, T itemToUpdate);
}