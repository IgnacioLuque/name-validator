using System.Text.RegularExpressions;

namespace NameValidatorApp;

public class NameValidator
{
    public bool IsValidName(string fullName)
    {
        var fullNameParts = fullName.Split(' ').ToList();

        if (fullNameParts.Count() < 2 ||
            fullNameParts.Count() > 3)
            return false;

        var lastName = fullNameParts.Last();

        if (!IsFullWord(lastName))
            return false;

        var names = fullNameParts.Where(x => x != lastName).ToList();
        var firstName = names.First();

        if (names.Count() == 2)
        {
            var secondName = names.Last();

            if (IsFullWord(secondName) && IsInitialLetter(firstName))
                return false;

            if (!IsInitialLetter(secondName) && !IsFullWord(secondName))
                return false;
        }

        if (!IsInitialLetter(firstName) && !IsFullWord(firstName))
            return false;

        foreach (var fullNamePart in fullNameParts)
        {
            if (!IsCapitalized(fullNamePart))
                return false;
        }

        return true;
    }

    private bool IsFullWord(string word)
    {
        var fullWordPattern = new Regex(@"\A[A-Za-z]{1}[a-z]{1,}\z");

        var isFullWord = fullWordPattern.IsMatch(word);

        return isFullWord;
    }

    private bool IsInitialLetter(string word)
    {
        var initialLetterPattern = new Regex(@"\A[A-Za-z]{1}\.{1}\z");

        var isInitialLetter = initialLetterPattern.IsMatch(word);

        return isInitialLetter;
    }

    private bool IsCapitalized(string word)
    {
        var firstLetter = word.First();
        var isUpper = Char.IsUpper(firstLetter);

        return isUpper;
    }
};
