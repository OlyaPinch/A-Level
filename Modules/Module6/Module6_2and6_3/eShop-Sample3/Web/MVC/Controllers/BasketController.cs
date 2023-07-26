using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.ViewModels.BasketViewModels;

namespace MVC.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IActionResult> Basket()
    {
    
        var vm = new BasketViewModels()
        {
            Basket = await _basketService.GetBasket()
        };
        return View(vm);
    }

    public async Task<IActionResult> AddToBasket(CatalogItem model)
    {
     
        await _basketService.AddItem(model);

        return RedirectToAction("Basket");
    }
}