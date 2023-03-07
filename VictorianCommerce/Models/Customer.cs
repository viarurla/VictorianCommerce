using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VictorianCommerce.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public string Forename { get; set; }
    public string Surname { get; set; }
    public virtual List<Purchase> Purchases { get; set; }
}