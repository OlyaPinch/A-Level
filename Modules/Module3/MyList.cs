using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module3
{
    public class MyList<T> 
    {
        private T[] myArray = Array.Empty<T>();

        public T this[int index]
        {
            get => myArray[index];
            set => myArray[index] = value;
        }

        private int position = -1;
        private int _count;

        public int Count => _count;

        List<int> h = new List<int>();


        public T[] Add(T item)
        {
            T[] tempArray = new T[myArray.Length + 1];
            myArray.CopyTo(tempArray, 0);
            myArray = tempArray;
            myArray[_count] = item;
            _count = myArray.Length;

            return myArray;
        }

        public void Clear()
        {
            _count = 0;
        }

        public T[] AddRange(T[] array)
        {
            T[] tempArray = new T[myArray.Length + array.Length];

            myArray.CopyTo(tempArray, 0);
            array.CopyTo(tempArray, _count);
            myArray = tempArray;
            _count = myArray.Length;

            return myArray;
        }

        public T[] RemoveAt(int index)
        {
            T[] tempArray = new T[myArray.Length - 1];
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (i < index)
                {
                    tempArray[i] = myArray[i];
                }
                else
                {
                    tempArray[i] = myArray[i + 1];
                }
            }

            myArray = tempArray;
            _count = myArray.Length;

            return myArray;
        }

        public bool Contain(T item)
        {
            bool isExist = false;


            for (int i = 0; i < myArray.Length - 1; i++)
                if (myArray[i].Equals(item))
                {
                    isExist = true;
                    break;
                }

            return isExist;
        }

        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < myArray.Length - 1; i++)
                if (myArray[i].Equals(item))
                {
                    index = i;
                }

            return index;
        }

        public bool Remove(T item)
        {
            {
                if (IndexOf(item) != -1)
                {
                    this.RemoveAt(IndexOf(item));
                    return true;
                }
                else return false;
            }
        }

        public T[] Sort()
        {
            Array.Sort(myArray);
            return myArray;
        }


        public IEnumerator GetEnumerator()
        {
            return myArray.GetEnumerator();
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}