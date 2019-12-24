using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzCSharp
{
    class Joueur
    {
        /// <summary>
        /// Nom du joueur (Initialisé en majuscules)
        /// </summary>
        public string Nom { get; }
        /// <summary>
        /// Prénom du joueur
        /// </summary>
        public string Prénom { get; }

        /// <summary>
        /// Constructeur de joueur, acceptant deux string nom et prénom en paramètre
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="prénom">Prénom du joueur</param>
        public Joueur(string nom, string prénom)
        {
            Nom = nom.ToUpper();
            Prénom = prénom;
        }

        /// <summary>
        /// Méthode ToString qui retourne les valeurs, en string, de l'objet joueur
        /// </summary>
        /// <returns>Retourne le nom et le prénom du joueur</returns>
        public override string ToString()
        {
            return $"{Nom} {Prénom}";
        }

        /// <summary>
        /// Permet la saisie du nom et prénom du joueur afin de créer un objet joueur
        /// par l'intermédiaire du constructeur
        /// </summary>
        /// <returns>Retourne le joueur créé</returns>
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
