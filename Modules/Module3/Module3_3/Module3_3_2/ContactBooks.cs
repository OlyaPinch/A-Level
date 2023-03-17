using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_3_2
{
    internal class ContactBooks
    {
        readonly List<Contact> _contacts;

        public ContactBooks()
        {
            _contacts = new List<Contact>();
        }

        public ContactBooks(List<Contact> contacts)
        {
            this._contacts = contacts;
        }

        public List<Contact> GetContactByCountry(string country)
        {
            return _contacts.Where(i => i.Country.ToLower() == country.ToLower()).ToList();
        }

        public List<string> SelectAllName()
        {
            return _contacts.Select(i => i.Name).ToList();
        }

        public Contact ChooseContactByName(string name)
        {
            return _contacts.FirstOrDefault(i => i.Name == name);
        }

        public List<Contact> OrderContactByContryandName(string country)
        {
            return _contacts.Where(i => i.Country.ToLower() == country.ToLower()).OrderBy(i => i.Name).ToList();
        }

        public int CountContactByCountry(string country)
        {
            return _contacts.Where(i => i.Country.ToLower() == country.ToLower()).Count();
        }

        public List<Contact> ContactByEmailProv(string email)
        {
            return _contacts.Where(i => i.Email.Contains(email)).ToList();
        }
    }
}