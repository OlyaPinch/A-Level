namespace Module3_2
{
    internal class Program
    {
        public Func<int, int, double> powDelegate;

        static void Main(string[] args)
        {
            Class1 cl1 = new Class1();
            Class2 cl2 = new Class2();

            var value = cl2.Calc(cl1.Pow, 20, 2);
            cl1.ShowHandler(value(4));
            cl1.ShowHandler(value(30));
        }

        public static void Show(bool result)
        {
            Console.WriteLine(result);
        }
    }
}