using TextCopy;

namespace PasswordGenerator.Business;

public class PasswordGeneratorBusiness
{
    // Liste pour stocker l'historique des mots de passe générés
    static List<string> passwordHistory = new List<string>();

    /// <summary>
    /// Main method, called for create password
    /// </summary>
    public static void GeneratePassword()
    {
        Console.WriteLine();
        Console.Write("Entrez la longueur du mot de passe : ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Inclure des majuscules ? (O/N) : ");
        bool includeUppercase = Console.ReadLine().ToUpper() == "O";

        Console.Write("Inclure des chiffres ? (O/N) : ");
        bool includeDigits = Console.ReadLine().ToUpper() == "O";

        Console.Write("Inclure des caractères spéciaux ? (O/N) : ");
        bool includeSpecialChars = Console.ReadLine().ToUpper() == "O";

        // Générer le mot de passe en utilisant les options
        string password = PasswordGeneratorClass.GeneratePassword(length, includeUppercase, includeDigits, includeSpecialChars);

        Console.WriteLine();
        Console.WriteLine($"Votre mot de passe généré est : {password}");

        passwordHistory.Add(password);
        Console.WriteLine();
        Console.Write("Voulez-vous copier ce mot de passe dans le presse-papiers ? (O/N) : ");
        if (Console.ReadLine().ToUpper() == "O")
        {
            ClipboardService.SetText(password);
            Console.WriteLine("Le mot de passe a été copié dans le presse-papiers !");
        }

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }

    /// <summary>
    /// Show history of passwords created in this session
    /// </summary>
    public static void ShowHistory()
    {
        if (passwordHistory.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Aucun mot de passe dans l'historique.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Historique des mots de passe générés :");
            for (int i = 0; i < passwordHistory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {passwordHistory[i]}");
            }

            // Options supplémentaires
            Console.WriteLine("\nOptions :");
            Console.WriteLine("1. Copier un mot de passe dans le presse-papiers");
            Console.WriteLine("2. Supprimer un mot de passe");
            Console.WriteLine("3. Retour au menu principal");

            Console.Write("Choisissez une option : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CopyPassword();
                    break;
                case "2":
                    DeletePassword();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }

    /// <summary>
    /// Copy password in clipboard among the generated passwords
    /// </summary>
    public static void CopyPassword()
    {
        Console.Write("Entrez le numéro du mot de passe à copier : ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < passwordHistory.Count)
        {
            ClipboardService.SetText(passwordHistory[index]);
            Console.WriteLine("Le mot de passe a été copié dans le presse-papiers !");
        }
        else
        {
            Console.WriteLine("Numéro invalide.");
        }
    }

    /// <summary>
    /// Delete a password among the generated passwords
    /// </summary>
    public static void DeletePassword()
    {
        Console.Write("Entrez le numéro du mot de passe à supprimer : ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < passwordHistory.Count)
        {
            passwordHistory.RemoveAt(index);
            Console.WriteLine("Le mot de passe a été supprimé de l'historique.");
        }
        else
        {
            Console.WriteLine("Numéro invalide.");
        }
    }

}