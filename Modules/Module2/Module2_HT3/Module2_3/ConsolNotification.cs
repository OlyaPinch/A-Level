using Module2_3;

namespace Module2_3;

public class ConsolNotification : INotification
{
    public void Notify(string message, User user)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Dear  {user.Name} {user.LastName}  your order is: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}