using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HT2
{
    public interface IBakingSweet
    {
        List<Component> ComponentsList { get; set; }
        double Weight { get; }
        string Name { get; set; }
        void Description();
        void Bake();
    }

    public abstract class BakingSweet : IBakingSweet
    {
        public List<Component> ComponentsList { get; set; } = new List<Component>();

        public double Weight
        {
            get { return ComponentsList.Sum(i => i.Weight); }
        }

        public string Name { get; set; }
        public abstract void Bake();

        public void Description()
        {
            Console.WriteLine(new string('_', 50));               
            Console.WriteLine($"{Name} content:");

            foreach (var component in ComponentsList)
            {
                component.Print();
            }
        }
    }
}