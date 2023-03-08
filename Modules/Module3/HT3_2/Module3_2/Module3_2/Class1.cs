using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_2
{
    public delegate void ShowHandler(bool value);

    public class Class1
    {
        public ShowHandler ShowHandler = Program.Show;

        public double Pow(int x, int y)
        {
            return (double)(Math.Pow(x, y));
        }
    }
}