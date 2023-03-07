using VictorianCommerce.Models;

namespace VictorianCommerce.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
}