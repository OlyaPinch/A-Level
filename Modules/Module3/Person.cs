using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    public class Person : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public int CompareTo(object? obj)
        {
            var b = obj as Person;
            var a = this;
            if (a == null)
            {
                if (b == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (b == null)

                {
                    return 1;
                }
                else
                {
                    int retval = a.Id.CompareTo(b.Id);

                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return a.Id.CompareTo(b.Id);
                    }
                }
            }
        }
    }
}