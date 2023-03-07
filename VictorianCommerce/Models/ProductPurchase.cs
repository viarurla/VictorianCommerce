using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VictorianCommerce.Models;

[PrimaryKey(nameof(PurchaseId), nameof(ProductId))]
public class ProductPurchase
{
    public int PurchaseId { get; set; }
    public Purchase Purchase { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public decimal Quantity { get; set; }
}