using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant2For3_4
{
    internal class ContactBooks
    {
        private SortedDictionary<char, List<Contact>> _myContacs = new SortedDictionary<char, List<Contact>>();

        public void AddContact(Contact contact)
        {
            var firstLetter = char.ToUpper(contact.Name[0]);
            if (!_myContacs.ContainsKey(firstLetter))
            {
                _myContacs[firstLetter] = new List<Contact>();
            }

            _myContacs[firstLetter].Add(contact);
        }

        public IEnumerable<Contact> GetContactsByLetter(char letter)
        {
            return _myContacs[Char.ToUpper(letter)];
        }

        public IEnumerable<Contact> GetContactsByLetter(int num)
        {
            char letter = Char.Parse(num.ToString());

            return _myContacs[letter];
        }

        public List<Contact> GetContactsByLanguage(Language lang)
        {
            return _myContacs.SelectMany(i => i.Value).Where(i => i.Lanquage == lang).ToList();
        }
    }
}