namespace Module2_HT1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            
            var log = Logger.Instance();
            var action = new Actions(log);



            var start = new Starter(action, log);
            start.Run();
        }
    }
}