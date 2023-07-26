using System.Net;
using Infrastructure.Models.Basket;
using Infrastructure.Models.Order;
using Infrastructure.Models.Response;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Order.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderBffController : ControllerBase
{
    private readonly ILogger<OrderBffController> _logger;

    private readonly IEntityService<BasketData, OrderData> _orderService;

    public OrderBffController(ILogger<OrderBffController> logger, IEntityService<BasketData, OrderData> orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }
    [HttpPost]
   
    public async Task<IActionResult> Add(BasketData basketData)
    {
        var buyerId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var result = await _orderService.Add(basketData);
        
        return Ok(result);
    }
    [HttpGet]
    [ProducesResponseType(typeof(OrderData), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(int id)
    {
        var result = await _orderService.GetItemById(id);
        return Ok(result);
    }
}