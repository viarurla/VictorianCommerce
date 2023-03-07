using VictorianCommerce.Models;

namespace VictorianCommerce.ViewModels;

public class PurchaseInDto
{
    public int CustomerId { get; set; }
    public List<ProductPurchaseInDto> Products { get; set; }
}