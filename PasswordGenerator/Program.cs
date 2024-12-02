using PasswordGenerator.Business;

class Program
{

    static void Main(string[] args)
    {
        while (true)
        {
            // Menu principal
            Console.Clear();
            Console.WriteLine(" ####                                                 #   ###                                       " +
                              "#\r\n #   #                                                #  #   #                                    " +
                              "  #\r\n #   #   ###    ###    ###   #   #   ###   # ##    ## #  #       ###   # ##    ###   # ##    ###   " +
                              "####    ###   # ##\r\n ####       #  #      #      #   #  #   #  ##  #  #  ##  #      #   #  ##  #  #   #  ##" +
                              "  #      #   #     #   #  ##  #\r\n #       ####   ###    ###   # # #  #   #  #      #   #  #  ##  #####  #   #" +
                              "  #####  #       ####   #     #   #  #\r\n #      #   #      #      #  # # #  #   #  #      #  ##  #   #  #      #" +
                              "   #  #      #      #   #   #  #  #   #  #\r\n #       ####  ####   ####    # #    ###   #       ## #   ###    ###   " +
                              "#   #   ###   #       ####    ##    ###   #\r\n\r\n\r\n");
            Console.WriteLine("Générateur de mot de passe");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Générer un mot de passe");
            Console.WriteLine("2. Voir l'historique des mots de passe");
            Console.WriteLine("3. Quitter");
            Console.WriteLine();
            Console.Write("Choisissez une option : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PasswordGeneratorBusiness.GeneratePassword();
                    break;
                case "2":
                    PasswordGeneratorBusiness.ShowHistory();
                    break;
                case "3":
                    return;  // Quitter l'application
                default:
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                    break;
            }
        }
    }

}
