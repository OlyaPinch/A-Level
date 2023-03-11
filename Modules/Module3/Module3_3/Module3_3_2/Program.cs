using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Module3_3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contact> myContacts = new List<Contact>() { };

            Contact c1 = new Contact();
            c1.Name = "Name1";
            c1.Country = "Ukraine";
            c1.Email = "email1@gmail.com";
            c1.PhoneNumber = "+38 067 000-00-01";

            Contact c2 = new Contact();
            c2.Name = "Name2";
            c2.Country = "Ukraine";
            c2.Email = "email2@ukr.net";
            c2.PhoneNumber = "+38 067 000-00-02";

            Contact c3 = new Contact();
            c3.Name = "Name3";
            c3.Country = "Ukraine";
            c3.Email = "email3@gmail.com";
            c3.PhoneNumber = "+38 067 000-00-03";

            Contact c4 = new Contact();
            c4.Name = "Name4";
            c4.Country = "France";
            c4.Email = "email4@ukr.net";
            c4.PhoneNumber = "+38 067 000-00-04";


            myContacts.Add(c1);
            myContacts.Add(c2);
            myContacts.Add(c3);
            myContacts.Add(c4);
            myContacts.Add(c1);
            myContacts.Add(c2);
            myContacts.Add(c3);
            myContacts.Add(c4);
            ContactBooks myBooks = new ContactBooks(myContacts);
            //1
            var contact = myBooks.ChooseContactByName("Name2");
            contact.PrintContact();
            //2
            var names = myBooks.SelectAllName();

            foreach (string name in names)
            {
                Console.Write(name + ", ");
                if (name == names.Last())
                {
                    Console.WriteLine("\n");
                }
            }

            //3
            var contactByCountry = myBooks.GetContactByCountry("Ukraine");
            foreach (Contact contact1 in contactByCountry)
            {
                contact1.PrintContact();
            }

            //4
            var contacsOrder = myBooks.OrderContactByContryandName("Ukraine");
            foreach (Contact contact1 in contacsOrder)
            {
                contact1.PrintContact();
            }

            //5
            Console.WriteLine(myBooks.CountContactByCountry("france"));
            //6
            var contbyEmail = myBooks.ContactByEmailProv("@ukr.net");
            foreach (Contact contact1 in contbyEmail)
            {
                contact1.PrintContact();
            }
        }
    }
}