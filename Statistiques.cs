using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuizzCSharp
{
    static class Statistiques
    {
        /// <summary>
        /// Constante PATH représentant le chemin du fichier de résultats
        /// </summary>
        const string PATH = "..\\..\\..\\RésultatsQuizz.txt";

        /// <summary>
        /// Fonction qui va lire et afficher les statistiques des résultats de toutes les précédentes parties enregistrées 
        /// </summary>
        public static void Afficher()
        {
            //Parcours le fichier de résultats
            string[] Lignes = File.ReadAllLines(PATH, Encoding.UTF8);

            List<int> scores = new List<int>();
            List<string> erreurs = new List<string>();
            List<int> statQuestions = new List<int>();
            SortedList<int, double> tauxRéussite = new SortedList<int, double>();

            Console.WriteLine($"Nombre total de jeux : {Lignes.Length - 1}");

            //Parcours chaque ligne du fichier, et récupère les scores ainsi qu'une version brute des erreurs dans des listes
            for (int i = 1; i < Lignes.Length; i++)
            {
                string[] scoreErreurs = Lignes[i].Split('/');
                string score = scoreErreurs[0];
                erreurs.Add(scoreErreurs[1]);
                scores.Add(Convert.ToInt32((score[^2].ToString() + score[^1].ToString()).ToString().Trim()));
            }
            Console.WriteLine($"Score moyen : {scores.Average()}");

            //Parcours la liste d'erreurs brute, pour compléter une nouvelle liste d'erreurs clarifiée
            foreach (var item in erreurs)
            {
                //Vérifie s'il y a bien quelque chose après la tabulation (Peut être vide si un joueur a bien répondu à toutes les questions)
                if (!string.IsNullOrEmpty(item.Split('\t')[1]))
                {
                    //Retire la tabulation, puis complète un tableau qui récupère les numéros de chaque question entre chaque virgule
                    string[] erreurQuestions = item.Split('\t')[1].Remove(0, 1).Split(',');

                    //Parcours ce dernier tableau pour compléter une liste d'entiers référençant les numéros des questions
                    foreach (var e in erreurQuestions)
                    {
                        //Vérifie que la valeur récupérée peut être convertie en entier
                        if (int.TryParse(e, out int b))
                            statQuestions.Add(Convert.ToInt32(e));
                    }
                }
            }

            Console.WriteLine($"Pourcentage de bonnes réponses pour les questions : ");

            //Pour chaque question, assigne dans une liste triée son taux de réussite associé
            for (int i = 1; i < DAL.GetQuestions().Count + 1; i++)
            {
                tauxRéussite.Add(i, Convert.ToDouble((Lignes.Length - 1) - statQuestions.Count(s => s == i)) / (Lignes.Length - 1) * 100);
            }

            //Parcours la liste triée et affiche les questions et leur taux de réussite dans l'ordre croissant de ce dernier
            foreach (var item in tauxRéussite.OrderBy(t => t.Value))
            {
                Console.WriteLine($"Question {item.Key} : {item.Value} %");
            }
        }
    }
}
