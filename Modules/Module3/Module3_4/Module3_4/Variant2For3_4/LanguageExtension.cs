using System.Globalization;

namespace Variant2For3_4;

public static class LanguageExtension
{
    private const string EnLetter = "en-US";
    private const string UkLetter = "uk-UA";


    private static readonly CultureInfo _enCulture = new(EnLetter);
    private static readonly CultureInfo _ukCulture = new(UkLetter);

    public static Language DefineLanguage(char letter)
    {
        if (!char.IsLetter(letter))
        {
            int num;
            if (Int32.TryParse(letter.ToString(), out num))
                return Language.Number;
            throw new InvalidOperationException();
        }

        var unicodeChar = char.GetUnicodeCategory(letter);
        if (unicodeChar != UnicodeCategory.UppercaseLetter && unicodeChar != UnicodeCategory.LowercaseLetter)
        {
            throw new InvalidOperationException();
        }

        if (_enCulture.CompareInfo.IndexOf("abcdefghijklmnopqrstuvwxyz", letter.ToString(),
                CompareOptions.IgnoreCase) >= 0)
        {
            return Language.English;
        }

        if (_ukCulture.CompareInfo.IndexOf("абвгґдеєжзиіїйклмнопрстуфхцчшщьюя", letter.ToString(),
                CompareOptions.IgnoreCase) >= 0)
        {
            return Language.Ukrainian;
        }

        throw new InvalidOperationException($"Does not supported language for letter: {letter}");
    }
}