using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_4
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Name {Name} {Surname} \t {PhoneNumber}";
        }
    }
}