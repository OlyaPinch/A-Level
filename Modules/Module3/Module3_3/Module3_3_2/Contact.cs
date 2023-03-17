using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_3_2
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public String Email { get; set; }
        public string PhoneNumber { get; set; }

        public void PrintContact()
        {
            Console.WriteLine($"{Name}\t{Country}\t{PhoneNumber}\t{Email}");
        }
    }
}