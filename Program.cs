using System;
using System.Collections.Generic;

namespace QuizzCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Partie partie = new Partie();
            //Joueur joueur = Joueur.CréerJoueur();

            //Console.Clear();

            //partie.InitialiserPartie();
            //partie.PoserQuestions();
            //partie.AfficherRésultat();

            //Résultats.CompléterFichier(joueur, partie.Score, partie.Erreurs);

            //Console.ReadKey();

            //Console.WriteLine("Voulez vous voir les statistiques du jeu ? (o)");
            //if (Console.ReadKey().KeyChar == 'o')
            //{
                Statistiques.Afficher();
            //}

            //Console.WriteLine("Appuyez sur Q pour fermer l'application.");
            //Console.ReadKey();


            Console.ReadKey();
        }
    }
}
