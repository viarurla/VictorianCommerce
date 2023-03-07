using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VictorianCommerce.Data;
using VictorianCommerce.Interfaces;
using VictorianCommerce.Models;
using VictorianCommerce.ViewModels;

namespace VictorianCommerce.Services;

public class PurchaseService : IPurchaseService
{
    private readonly ILogger<PurchaseService> _logger;
    private readonly CommerceContext _context;
    private readonly IMapper _mapper;

    public PurchaseService(ILogger<PurchaseService> logger, CommerceContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PurchaseOutDto> AddPurchaseAsync(PurchaseInDto purchase)
    {
        var parsedPurchase = _mapper.Map<Purchase>(purchase);
        parsedPurchase.OrderedAt = DateTime.Now;
        await _context.Purchases.AddAsync(parsedPurchase);
        await _context.SaveChangesAsync();

        foreach (var purchaseProduct in purchase.Products)
        {
            await _context.ProductPurchases.AddAsync(new()
            {
                PurchaseId = parsedPurchase.Id,
                ProductId = purchaseProduct.ProductId,
                Quantity = purchaseProduct.Quantity
            });
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<PurchaseOutDto>(parsedPurchase);
    }

    public async Task<IEnumerable<PurchaseOutDto>> GetPurchasesAsync()
    {

        var purchases =  await _context.Purchases.Select(p => _mapper.Map<PurchaseOutDto>(p)).ToListAsync();
        return purchases;
    }

}