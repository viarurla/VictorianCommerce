using Microsoft.EntityFrameworkCore;
using VictorianCommerce.Data;
using VictorianCommerce.Interfaces;
using VictorianCommerce.Models;

namespace VictorianCommerce.Services;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly CommerceContext _context;

    public ProductService(ILogger<ProductService> logger, CommerceContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}