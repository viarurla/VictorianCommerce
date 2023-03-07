using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace VictorianCommerce.Models;

public class Purchase
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderedAt { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual List<ProductPurchase> ProductsPurchases { get; set; }
    
}