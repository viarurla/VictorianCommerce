using VictorianCommerce.Interfaces;
using VictorianCommerce.Models;
using VictorianCommerce.ViewModels;

namespace VictorianCommerce.Validators;

public class PurchaseValidator : IPurchaseValidator
{
    private readonly ILogger<PurchaseValidator> _logger;
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;

    private readonly List<ValidationIssue> _issues = new();

    public PurchaseValidator(ILogger<PurchaseValidator> logger, ICustomerService customerService, IProductService productService)
    {
        _logger = logger;
        _customerService = customerService;
        _productService = productService;
    }

    public async Task<List<ValidationIssue>> Validate(PurchaseInDto purchase)
    {
        await ValidateCustomer(purchase);
        await ValidateProducts(purchase);
        return _issues;
    }

    private async Task ValidateCustomer(PurchaseInDto purchase)
    {
        var customers = await _customerService.GetCustomersAsync();
        if (customers.Any(c => c.Id == purchase.CustomerId))
        {
            return;
        }
        _issues.Add(new ValidationIssue()
        {
           Message = $"Customer with Id of {purchase.CustomerId} does not exist"
        });
    }

    private async Task ValidateProducts(PurchaseInDto purchase)
    {
        var products = await _productService.GetProductsAsync();
        foreach (ProductPurchaseInDto product in purchase.Products.Where(product => !products.Select(p => p.Id == product.ProductId).Any()))
        {
            _issues.Add(new ValidationIssue
            {
                Message = $"Product with Id of {product.ProductId} does not exist"
            });
        }
    }

}