using System.Collections.Generic;
using System.Net;

namespace Module3_7
{
    public delegate Task<List<Contact>> ContactsEventHandler(List<Contact> contacts);

    internal class Program
    {
        public static event ContactsEventHandler ContactsEvent;

        static async Task Main(string[] args)
        {
            var taskCompletionSource = new TaskCompletionSource();
            List<Contact> contacts = GenereteRandomList(20);
            
            ContactsEvent += GetUniqueContacts;
            ContactsEvent += GetFirstThreeContacts;
            ContactsEvent += GetSortedContacts;
            
            var allDelegates = ContactsEvent.GetInvocationList()
                .Select(i => (Task<List<Contact>>)i.DynamicInvoke(contacts));
           
            var objects = allDelegates.ToArray();
            Task.WaitAll(objects);
            var selectMany = objects.Select(i => i.Result).SelectMany(i => i).ToList();

            foreach (var contact in selectMany)
            {
                Console.WriteLine(contact);
            }

            await taskCompletionSource.Task;
        }


        public static async Task<List<Contact>> GetUniqueContacts(List<Contact> contacts)
        {
            await Task.Delay(3000);


            return await Task.FromResult(contacts.Distinct().ToList());
        }

        public static async Task<List<Contact>> GetFirstThreeContacts(List<Contact> contacts)
        {
            await Task.Delay(3000);
            
            return await Task.FromResult(contacts.Take(3).ToList());
        }

        public static async Task<List<Contact>> GetSortedContacts(List<Contact> contacts)
        {
            await Task.Delay(3000);
            return await Task.FromResult((contacts.OrderBy(i => i.Name).Where(i => i.PhoneNumber[0] == '1')).ToList());
        }

        public static List<Contact> GenereteRandomList(int quantity)
        {
            List<Contact> contacts = new List<Contact>();
            Random rnd = new Random();
            string[] firstNames =
            {
                "Adam", "Alex", "Bob", "David", "Eva", "Frank", "George", "Helen", "Ivy", "Jack",
                "Karen", "Liam", "Mark", "Nancy", "Oliver", "Paul", "Quinn", "Ryan", "Sophie", "Tom",
                "Violet", "William", "Xander", "Yara", "Zoe"
            };

            for (int i = 0; i < quantity; i++)
            {
                int firstNameIndex = rnd.Next(firstNames.Length);
                string firstName = firstNames[firstNameIndex];
                string surname = $"Surname_{i}";
                string phoneNumber = $"{rnd.Next(100000000, 999999999)}";
                string city = "";

                contacts.Add(new Contact(firstName, surname) { PhoneNumber = phoneNumber, City = city });
            }

            return contacts;
        }
    }
}