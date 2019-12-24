using System;
using System.Collections.Generic;

namespace QuizzCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Créé une nouvelle partie
            Partie partie = new Partie();
            //Créé le joueur pour la session
            Joueur joueur = Joueur.CréerJoueur();

            Console.Clear();

            //Lance la partie, puis pose les questions, avant d'afficher le résultat du test
            partie.InitialiserPartie();
            partie.PoserQuestions();
            partie.AfficherRésultat();

            //Complète le fichier avec les résultats du joueur
            Résultat.CompléterFichier(joueur, partie.Score, partie.Erreurs);

            Console.Clear();

            //Propose à l'utilisateur de montrer les statistiques du jeu
            Console.WriteLine("Voulez vous voir les statistiques du jeu ? (o)");
            if (Console.ReadKey().KeyChar == 'o')
            {
                Console.Clear();
                Statistiques.Afficher();
            }

            //Ferme l'application quand l'utilisateur appuie sur la touche Q
            Console.WriteLine("Appuyez sur Q pour fermer l'application.");
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.Clear();
                Console.WriteLine("Appuyez sur Q pour fermer l'application.");
            }
        }
    }
}
