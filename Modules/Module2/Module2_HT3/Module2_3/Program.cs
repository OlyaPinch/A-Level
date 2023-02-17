using Module2_3;

namespace Module2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataManager manager;
            INotification notification = new ConsolNotification();
            Console.WriteLine("Please, select storage for shop:");
            Console.WriteLine("1. File storage\n2. Memory storage");
            string readLine = Console.ReadLine();
            if (readLine == "1")
            {
                manager = new FileDataManager();
            }
            else
            {
                manager = new MemoryDataManager();
            }

            var shop = new Shop(manager, notification);
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                shop.AddToShoppingCard(shop.Products[rand.Next(0, 10)]);
            }

            shop.CheckOut();

            for (int i = 0; i < 10; i++)
            {
                shop.AddToShoppingCard(shop.Products[rand.Next(0, 10)]);
            }

            shop.CheckOut();

            Console.ReadKey();
        }
    }
}