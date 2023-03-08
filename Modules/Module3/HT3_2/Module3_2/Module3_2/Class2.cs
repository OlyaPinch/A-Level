using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_2
{
    internal class Class2
    {
        public Func<double, bool> ResultDelegate;


        private double result;

        public Class2()
        {
            ResultDelegate = Result;
        }

        public Func<double, bool> Calc(Func<int, int, double> PowHadler, int x, int y)
        {
            result = PowHadler(x, y);
            return ResultDelegate;
        }

        public bool Result(double divisor)
        {
            if (divisor == 0)
            {
                return false;
            }

            return result % divisor == 0;
        }
    }
}