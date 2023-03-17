namespace Module3_5
{
    //Створити асинхронний метод, який асинхронно читатиме з файлу “Hello”
    //Створити асинхронний метод, який асинхронно читатиме з іншого файлу “World”
    // Створити асинхронний метод, у якому асинхронно виконуватимуться методи витягування тексту.
    // Дочекатися паралельне виконання двох методів та повернуть конкатенацію текстів як результат поточного методу
    // Синхронно запустити метод, який повертає результат контатенації

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var concatenatedText = await ConcatenateTextAsync();
            Console.WriteLine(concatenatedText);
        }

        static async Task<string> ReadFileAsync(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                return await reader.ReadToEndAsync();
            }
        }

        static async Task<string> ConcatenateTextAsync()
        {
            var helloTask = ReadFileAsync("Hello.txt");
            var worldTask = ReadFileAsync("World.txt");

            return $"{await helloTask}{await worldTask}";
        }
    }
}