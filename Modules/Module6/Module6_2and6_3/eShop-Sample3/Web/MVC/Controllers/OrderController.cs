using MVC.Services.Interfaces;

namespace MVC.Controllers;

public class OrderController: Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> Order()
    {

        var result = await _orderService.GetOrderItems();
    
        return View();
    }
}