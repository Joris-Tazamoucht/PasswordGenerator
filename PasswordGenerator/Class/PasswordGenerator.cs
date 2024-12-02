using System.Text;

public class PasswordGenerator
{
    private static readonly string Lowercase = "abcdefghijklmnopqrstuvwxyz";
    private static readonly string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly string Digits = "0123456789";
    private static readonly string SpecialCharacters = "!@#$%^&*()-_=+[]{}|;:,.<>?/";

    public static string GeneratePassword(int length, bool includeUppercase, bool includeDigits, bool includeSpecialChars)
    {
        StringBuilder availableChars = new StringBuilder(Lowercase);

        if (includeUppercase) availableChars.Append(Uppercase);
        if (includeDigits) availableChars.Append(Digits);
        if (includeSpecialChars) availableChars.Append(SpecialCharacters);

        Random random = new Random();
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            password[i] = availableChars[random.Next(availableChars.Length)];
        }

        return new string(password);
    }

    public static void PrintPasswordCriteria()
    {
        Console.WriteLine("Options de génération de mot de passe :");
        Console.WriteLine("1. Longueur du mot de passe");
        Console.WriteLine("2. Inclusion des majuscules");
        Console.WriteLine("3. Inclusion des chiffres");
        Console.WriteLine("4. Inclusion des caractères spéciaux");
    }
}