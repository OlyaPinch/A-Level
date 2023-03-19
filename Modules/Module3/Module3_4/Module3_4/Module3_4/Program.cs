using Microsoft.VisualBasic;
using System.Globalization;

namespace Module3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  var myDic=  MyTextForQuantityСhar("rrrbbbh");

            /*SortedDictionary<string, Contact> contacts = new SortedDictionary<string, Contact>();

            Contact c1 = new Contact();
            c1.Name = "Name1";
            c1.Surname = "BSurnemeName1";
            c1.PhoneNumber = "+380670000001";

            Contact c2 = new Contact();
            c2.Name = "Name2";
            c2.Surname = "ASurnemeName2";
            c2.PhoneNumber = "+380670000002";
            contacts.Add(c1.Surname,c1);
            contacts.Add(c2.Surname,c2);*/
            var contacts = new ContactBooks();

            contacts.AddContact(new Contact { Name = "John", PhoneNumber = "555-1234" });
            contacts.AddContact(new Contact { Name = "Jane", PhoneNumber = "555-5678" });
            contacts.AddContact(new Contact { Name = "Aob", PhoneNumber = "555-9012" });
            contacts.AddContact(new Contact { Name = "Андрій", PhoneNumber = "555-7890" });
            contacts.AddContact(new Contact { Name = "Андрій", PhoneNumber = "555-7890" });
            contacts.AddContact(new Contact { Name = "Антон", PhoneNumber = "555-7890" });
            contacts.AddContact(new Contact { Name = "Марія", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "5арія", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "1ФФФ", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "1ААА", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "1ИИИИ", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "1ІІІІ", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "1ФФФФ", PhoneNumber = "555-2345" });
            contacts.AddContact(new Contact { Name = "6", PhoneNumber = "555-2345" });


            var en = new CultureInfo("en-US");
            var uk = new CultureInfo("uk-UA");

            var foundEnContacts = contacts.GetContactsByLetter('J', en);

            foreach (var item in foundEnContacts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            var notFoundUkContacts = contacts.GetContactsByLetter('A', en);

            foreach (var item in notFoundUkContacts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");

            var foundAUkContacts = contacts.GetContactsByLetter('0', uk);

            foreach (var item in foundAUkContacts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            var foundMUkContacts = contacts.GetContactsByLetter(1);

            foreach (var item in foundMUkContacts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");

            var notFoundMUkContacts = contacts.GetContactsByLetter('m', en);
            foreach (var item in notFoundMUkContacts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
        }

        public static Dictionary<char, int> MyTextForQuantityСhar(string text)
        {
            return text.ToCharArray().GroupBy(i => i).ToDictionary(i => (char)i.Key, i => i.Count());
        }
    }
}