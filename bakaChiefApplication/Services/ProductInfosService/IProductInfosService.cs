using bakaChiefApplication.Models;

namespace bakaChiefApplication.Services.ProductInfosService;

public interface IProductInfosService
{
    Task<IEnumerable<ProductInfo>> GetProductsAsync();
}