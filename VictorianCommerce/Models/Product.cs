using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VictorianCommerce.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<ProductPurchase> ProductPurchases { get; set; }
}