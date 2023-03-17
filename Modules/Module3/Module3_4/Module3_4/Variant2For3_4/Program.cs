namespace Variant2For3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contactBooks = new ContactBooks();

            contactBooks.AddContact(new Contact("John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Jane", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Alex", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Андрій", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Антонhn", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Марія", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Маша", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("Маша", "smith") { PhoneNumber = "555-1234" });
           contactBooks.AddContact(new Contact("1ИИИИ", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("1ААА", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("1ФФФФ", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("2John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("3John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("4John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("John", "smith") { PhoneNumber = "555-1234" });
            contactBooks.AddContact(new Contact("John", "smith") { PhoneNumber = "555-1234" });

            var foundEnContacts = contactBooks.GetContactsByLanguage(Language.Ukrainian);

            foreach (var item in foundEnContacts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            var foundContactsByM = contactBooks.GetContactsByLetter('М');

            foreach (var item in foundContactsByM)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            var foundContactsByNumber = contactBooks.GetContactsByLetter(1);

            foreach (var item in foundContactsByNumber)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");

            var foundContactsByAenglish = contactBooks.GetContactsByLetter('a');

            foreach (var item in foundContactsByAenglish)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            var foundContactsByAUkraine = contactBooks.GetContactsByLetter('А');

            foreach (var item in foundContactsByAUkraine)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
            var foundContactsAllNumbers = contactBooks.GetContactsByLanguage(Language.Number);

            foreach (var item in foundContactsAllNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========");
        }
    }
}