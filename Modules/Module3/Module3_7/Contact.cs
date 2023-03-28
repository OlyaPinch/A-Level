using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_7
{
    public class Contact
    {
        public Contact(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public string  City { get; set; }


        public override string ToString()
        {
            return $"Name {Name} {Surname} \t {PhoneNumber}";
        }
    }
}