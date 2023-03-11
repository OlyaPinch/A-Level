using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_3
{
    public delegate int SumHandler(int x, int y);

    public class Calculator
    {
        public event SumHandler Sum;

        public void Example()
        {
            Wrapper(Sum);
        }

        public void Calculate(int x, int y)
        {


            HandleError(() => SumResult(x, y));
        }

        public void SumResult(int x, int y)
        {
            int sumResult = 0;
            var delegates = Sum.GetInvocationList();

            foreach (var d in delegates)
            {
                sumResult += Sum.Invoke(x, y);
            }

            Console.WriteLine($"Sum of {delegates.Length} mehot = {sumResult}");
        }

        private static void HandleError(Action sumHandler)
        {
            try
            {
                sumHandler();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private static void Wrapper(SumHandler sumHandler)
        {
            try
            {
                Console.WriteLine(sumHandler(10, 20));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}