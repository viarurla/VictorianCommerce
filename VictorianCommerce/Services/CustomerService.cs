using Microsoft.EntityFrameworkCore;
using VictorianCommerce.Data;
using VictorianCommerce.Interfaces;
using VictorianCommerce.Models;

namespace VictorianCommerce.Services;

public class CustomerService: ICustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly CommerceContext _context;

    public CustomerService(ILogger<CustomerService> logger, CommerceContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }
}