using System.ComponentModel;

namespace Module3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            calculator.Sum += Sum;
            calculator.Sum += Sum;
            calculator.Sum += Sum;


            calculator.Example();
          
            calculator.Calculate(1, 2);

            calculator.Sum -= Sum;
            calculator.Calculate(10, 10);
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }
    }
}