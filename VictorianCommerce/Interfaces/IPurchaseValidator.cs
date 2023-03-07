using VictorianCommerce.Models;
using VictorianCommerce.ViewModels;

namespace VictorianCommerce.Interfaces;

public interface IPurchaseValidator
{
    Task<List<ValidationIssue>> Validate(PurchaseInDto purchase);
}