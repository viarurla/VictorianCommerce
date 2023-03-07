using VictorianCommerce.Models;

namespace VictorianCommerce.Interfaces;

public interface ICustomerService
{
    
    Task<IEnumerable<Customer>> GetCustomersAsync();
}