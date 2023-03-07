using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using VictorianCommerce.Interfaces;
using VictorianCommerce.Models;
using VictorianCommerce.ViewModels;

namespace VictorianCommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchasesController : ControllerBase
{

    private readonly ILogger<PurchasesController> _logger;
    private readonly IPurchaseService _purchaseService;
    private readonly IPurchaseValidator _purchaseValidator;

    public PurchasesController(ILogger<PurchasesController> logger, IPurchaseService purchaseService, IPurchaseValidator purchaseValidator)
    {
        _logger = logger;
        _purchaseService = purchaseService;
        _purchaseValidator = purchaseValidator;
    }

    [HttpGet(Name = "GetPurchases")]
    public async Task<IEnumerable<PurchaseOutDto>> Get()
    {
        return await _purchaseService.GetPurchasesAsync();;
    }
    
    [HttpPost(Name = "PostPurchase")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(PurchaseInDto purchase)
    {
        var issues = await _purchaseValidator.Validate(purchase);
        if (issues.Any())
        {
            // Very rudimentary but sufficient as a proof of concept
            var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                ReasonPhrase = string.Join($", ", issues.Select(i => i.Message))
            };
            return new BadRequestObjectResult(resp);
        }

        var result = await _purchaseService.AddPurchaseAsync(purchase);
        return CreatedAtAction(nameof(Post), new {Id = result.Id}, result);
    }
}