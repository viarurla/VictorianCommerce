namespace VictorianCommerce.ViewModels;

public class PurchaseOutDto
{
    public int Id { get; set; }
    public DateTime OrderedAt { get; set; }
    public CustomerOutDto Customer { get; set; }
}