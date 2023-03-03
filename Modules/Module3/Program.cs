using System.Collections.Immutable;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Channels;

namespace Module3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myArray = new MyList<int>();
            myArray.Add(20);
            myArray.Add(23);
            myArray.Add(10);
            myArray.Add(500);
            foreach (var i in myArray)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine(new string('-', 10));

            int[] forAdd = new[] { 1000, 2000, 3000, 4000 };
            myArray.AddRange(forAdd);
            foreach (var i in myArray)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine(new string('-', 10));
            myArray.RemoveAt(3);
            myArray.Remove(20);
            foreach (var i in myArray)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine(new string('-', 10));
            MyList<Person> personList = new MyList<Person>();

            Person p1 = new Person(3, "CCCC");
            Person p2 = new Person(2, "BBBB");
            Person p3 = new Person(1, "AAAA");
            personList.Add(p1);
            personList.Add(p2);
            Person[] clArr = new Person[] { p3, p2 };
            personList.AddRange(clArr);
            Console.WriteLine(new string('-', 10));
            foreach (var i in myArray)
            {
                Console.WriteLine($"{i}");
            }

            personList.Sort();
            foreach (Person ex in personList)
            {
                Console.WriteLine($"list for example {ex.Id}  {ex.Name}");
            }

            myArray.Sort();
            foreach (var i in myArray)
            {
                Console.WriteLine($"{i}");
            }
         

        }
    }
}