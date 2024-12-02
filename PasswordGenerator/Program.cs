﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans le générateur de mot de passe !");
        PasswordGenerator.PrintPasswordCriteria();

        Console.Write("Entrez la longueur du mot de passe : ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Inclure des majuscules ? (O/N) : ");
        bool includeUppercase = Console.ReadLine().ToUpper() == "O";

        Console.Write("Inclure des chiffres ? (O/N) : ");
        bool includeDigits = Console.ReadLine().ToUpper() == "O";

        Console.Write("Inclure des caractères spéciaux ? (O/N) : ");
        bool includeSpecialChars = Console.ReadLine().ToUpper() == "O";

        string password = PasswordGenerator.GeneratePassword(length, includeUppercase, includeDigits, includeSpecialChars);

        Console.WriteLine($"Votre mot de passe généré est : {password} <br> Souhaitez vous l'enregistrer ?");
    }
}