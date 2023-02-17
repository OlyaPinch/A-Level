using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_3
{
    public class Product
    {
        public Product(string name, int id, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}