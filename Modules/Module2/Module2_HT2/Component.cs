using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HT2
{
    public class Component
    {
        public Component(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double  Weight{ get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name}: {Weight}g");
        }
    }
}
