namespace Module2_HT1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IFileService fileService= new FileService();
            var log = new Logger(fileService);

            var action = new Actions(log);

            var start = new Starter(action, log);
            start.Run();
        }
    }
}