using System.Transactions;

namespace Module2_3;

public class Shop
{
    private readonly IDataManager _dataManager;
    private readonly INotification _notify;

    public Product[] Products { get; set; }
    public List<Order> Orders { get; set; }

    public ShoppingCard ShoppingCard { get; set; }
    public List<User> Users { get; set; }

    public Shop(IDataManager dataManager, INotification notify)
    {
        _dataManager = dataManager;
        Init();
        ShoppingCard = new ShoppingCard();
        Orders = new List<Order>();
        Users = new List<User>();
        _notify = notify;
    }
    
    public void Init()
    {
        Products = _dataManager.LoadProducts();
    }

    public void AddToShoppingCard(Product product, int quantity = 1)
    {
        ShoppingCard.Add(product, quantity);
    }

    public void CheckOut()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        Console.Write("\nEnter your  last name: ");
        string? lastname = Console.ReadLine();
        User user = new User(name, lastname);
        Users.Add(user);

        Order order = new Order(ShoppingCard.OrderItems.ToList(), Orders.Count + 1, user.UserId);
        Orders.Add(order);
        ShoppingCard.OrderItems.Clear();
      _notify.Notify(order.Print(),user);
    }
}