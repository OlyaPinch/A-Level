using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module2_HT2
{
    internal static class OrderExtensions
    {
        public static OrderItem SearchByName(this Order order, string name)
        {

            return order.Items.FirstOrDefault(i=> i.OrderItems.Name == name);
            /*foreach (var element in order.Items)
            {
                if (element.OrderItems.Name== name)
                {
                    Console.WriteLine($" In order we have {element.OrderItems.Name} {element.Quantity}  item  ");
                }
            }*/
        }

      
        public static double OrderWeight(this Order order)
        {
            return order.Items.Sum(i => i.OrderItems.Weight * i.Quantity);
        }
    }
}