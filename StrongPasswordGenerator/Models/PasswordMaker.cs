using System.Text;

namespace StrongPasswordGenerator.Models;

public class PasswordMaker
{
    private readonly char[] _characters = { '@', '#', '!', '*', '%', '$' };
    private readonly Random _random = new Random();
    private readonly Dictionary<char, int> _lettersToConvertInNumbers = new Dictionary<char, int>();

    public PasswordMaker()
    {
        LoadLettersToConvert();
    }

    private void LoadLettersToConvert()
    {
        _lettersToConvertInNumbers.Add('a', 4);
        _lettersToConvertInNumbers.Add('i', 1);
        _lettersToConvertInNumbers.Add('e', 3);
        _lettersToConvertInNumbers.Add('o', 0);
    }

    public string GeneratePassword(string passwordKey)
    {
        if (!IsValidPasswordKey(passwordKey))
        { 
            throw new Exception("Insira uma palavra chave para criar a senha");
        }
        
        var resultPassword = new StringBuilder();
        resultPassword.Append(GetRandomCharacter());

        foreach (var letterPasswordKey in passwordKey)
        {
            if (_lettersToConvertInNumbers.TryGetValue(letterPasswordKey, out var convertedLetter)) 
                resultPassword.Append(convertedLetter);
            else
                resultPassword.Append(RandomConvertLetterCase(letterPasswordKey));
        }
        
        resultPassword.Append(GetRandomCharacter());

        return resultPassword.ToString();
    }

    private bool IsValidPasswordKey(string passwordKey) => passwordKey != String.Empty;

    private char GetRandomCharacter()
    {
        return _characters[_random.Next(0, _characters.Length - 1)];
    } 

    private string RandomConvertLetterCase(char letter)
    {
        return _random.Next(0, 2) == 0 ? letter.ToString().ToUpper() : letter.ToString().ToLower();
    }
}