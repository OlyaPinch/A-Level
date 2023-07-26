using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Models.Basket;
using Infrastructure.Models.Requests;
using Infrastructure.Models.Response;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AnonimedLogger(TestAddRequest data)
    {
        _logger.LogInformation(data.Data);
        return await Task.FromResult(Ok());
    }
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DefendedLogger(TestAddRequest data)
    {
        _logger.LogInformation(User.Claims.FirstOrDefault(x => x.Type == "client_id")?.Value);
        return await Task.FromResult(Ok());
    }

    /*[HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> TestAdd(DataRequest<string?> data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.Add(basketId!, data.Data);
        return Ok();
    }*/

    [HttpPost]
    [ProducesResponseType(typeof(List<BasketDataItem>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.Get(basketId!);
        return Ok(response);
    }
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(DataRequest<ProductItem> data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.Add(data.Data,basketId);
        return Ok();
    }
}