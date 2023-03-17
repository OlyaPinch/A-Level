using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant2For3_4
{
    public enum Language
    {
        English,
        Ukrainian,
        Number
    }

    public class Contact
    {
        public Contact(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Lanquage = LanguageExtension.DefineLanguage(Name[0]);
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public Language Lanquage { get; }


        public override string ToString()
        {
            return $"Name {Name} {Surname} \t {PhoneNumber}";
        }
    }
}