using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.ProductInfosService;

public interface IProductInfosService
{
    /// <summary>
    /// Get Products with limit
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ProductInfo>> GetProductsAsync();
    
    /// <summary>
    /// Get Products search by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<IEnumerable<ProductInfo>> GetProductsByNameAsync(string name);
}