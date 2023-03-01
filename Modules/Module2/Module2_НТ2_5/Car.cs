using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module2_НТ2_5
{
    public interface ICar
    {
        string BrandCar { get; set; }
        int YearOfProduction { get; set; }
        TypeOfFuel TypeOfFuel { get; set; }
        int Price { get; set; }
        void PrintCar();
    }

    public abstract class Car : ICar
    {
        public string BrandCar { get; set; }
        public int YearOfProduction { get; set; }
        public TypeOfFuel TypeOfFuel { get; set; }
        public int Price { get; set; }

        public virtual void PrintCar()
        {
            Console.Write($"{BrandCar}\t{YearOfProduction}\t{TypeOfFuel}\t{Price}\t");
        }
    }
}