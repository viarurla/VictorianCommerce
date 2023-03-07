using System.Collections;
using VictorianCommerce.Models;
using VictorianCommerce.ViewModels;

namespace VictorianCommerce.Interfaces;

public interface IPurchaseService
{
    Task<PurchaseOutDto> AddPurchaseAsync(PurchaseInDto purchase);
    Task<IEnumerable<PurchaseOutDto>> GetPurchasesAsync();
}