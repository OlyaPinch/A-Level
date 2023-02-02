namespace Module1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var letterOffset = 64;

            int arrayLength;

            bool realNumber;
            int maxLength = int.MaxValue;
            bool corectLength;
            do
            {
                Console.WriteLine($"Enter length of array from 1 to {maxLength}");
                realNumber = int.TryParse(Console.ReadLine(), out arrayLength);
                corectLength = realNumber && maxLength >= arrayLength && arrayLength > 0;
            } while (!corectLength);

            int[] myArray = new int[arrayLength];

            Console.WriteLine($"\nwe make array from  {arrayLength} elements\n");
            int countEvenNumber = 0;
            int countOddNumber = 0;


            for (int i = 0; i < arrayLength; i++)
            {
                myArray[i] = new Random().Next(1, 27);
                if (myArray[i] % 2 != 1)
                    countEvenNumber++;
                else
                    countOddNumber++;
            }

            int indexEvenArray = 0, indexOddArray = 0;
            int[] evenArray = new int[countEvenNumber];
            int[] oddArray = new int[countOddNumber];

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] % 2 != 1)
                {
                    evenArray[indexEvenArray] = myArray[i];
                    indexEvenArray++;
                }


                else
                {
                    oddArray[indexOddArray] = myArray[i];
                    indexOddArray++;
                }
            }


            PrintArray(myArray, nameof(myArray));
            PrintArray(evenArray, nameof(evenArray));

            const string ALFABET = "abcdefghilklmnopqrstuvwxyz";
            char[] letterFromEvenArray = new char[evenArray.Length];
            char[] letterFromOddArray = new char[oddArray.Length];
            string mustBeUp = "aeldhj";

            for (int i = 0; i < evenArray.Length; i++)
            {
                letterFromEvenArray[i] = ALFABET[evenArray[i] - 1];

                if (mustBeUp.Contains(letterFromEvenArray[i]))
                {
                    letterFromEvenArray[i] = char.ToUpper(letterFromEvenArray[i]);
                }
            }


            for (int i = 0; i < oddArray.Length; i++)
            {
                letterFromOddArray[i] = ALFABET[oddArray[i] - 1];

                if (mustBeUp.Contains(letterFromOddArray[i]))
                {
                    letterFromOddArray[i] = char.ToUpper(letterFromOddArray[i]);
                }
            }

            PrintArray(letterFromEvenArray, nameof(letterFromEvenArray));
            PrintArray(oddArray, nameof(oddArray));
            PrintArray(letterFromOddArray, nameof(letterFromOddArray));
        }

        public static void PrintArray(int[] myArray, string header, string description = null)
        {
            string text = $"\n{description + " Array",50} : {header}\n";
            Console.WriteLine(text);

            Console.Write(string.Join(", ", myArray));
            Console.WriteLine("\n" + new string('-', 100));

            Console.Write("\n");
        }

        public static void PrintArray(char[] myArray, string header)
        {
            string text = $"\n{" Array",50} : {header}\n";
            Console.WriteLine(text);

            Console.Write(string.Join(", ", myArray));
            Console.WriteLine("\n" + new string('-', 100));

            Console.Write("\n");
        }
    }
}