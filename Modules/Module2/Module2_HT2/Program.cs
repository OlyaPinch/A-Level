namespace Module2_HT2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBakingSweet cake1 = new Cake();
            IBakingSweet cake2 = new CakeWithGlaze("chocolate");
            IBakingSweet cake3 = new CakeWithGlaze("caramel");
            IBakingSweet cake4 = new CakeWithJam("apple jam");

            cake1.Description();
            cake2.Description();
            cake3.Description();
            cake4.Description();
            
            OrderItem[] orderItems = { new OrderItem(cake1, 3), new OrderItem(cake2, 5), new OrderItem(cake3, 10), new OrderItem(cake4, 2) };

            var order = new Order(orderItems);
            Console.WriteLine(order.OrderWeight());
           
            OrderItem mySearch= order.SearchByName("Standard Cake");
            Console.WriteLine($"{mySearch.Quantity} items  of {mySearch.OrderItems.Name}");

            mySearch= order.SearchByName(cake3.Name);
            Console.WriteLine($"{mySearch.Quantity} items  of {mySearch.OrderItems.Name}");
        }
    }
}