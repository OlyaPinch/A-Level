using Infrastructure.Models.Order;

namespace MVC.ViewModels.OrderViewModels;

public class OrderViewModel
{
    public List<OrderItemData> Order{ get; set; }
}