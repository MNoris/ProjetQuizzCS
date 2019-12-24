using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzCSharp
{
    class Joueur
    {
        public string Nom { get; set; }
        public string Prénom { get; set; }

        public Joueur(string nom, string prénom)
        {
            Nom = nom.ToUpper();
            Prénom = prénom;
        }

        public string GetNomPrénom()
        {
            return $"{Nom} {Prénom}";
        }

        public static Joueur CréerJoueur()
        {
            Console.WriteLine("Veuillez entrer votre nom, puis ensuite votre prénom.");
            Console.WriteLine("Nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            string prénom = Console.ReadLine();

            return new Joueur(nom, prénom);
        }
    }
}
