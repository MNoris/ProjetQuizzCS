using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuizzCSharp
{
    static class Statistiques
    {
        const string PATH = "C:\\Quizz\\RésultatQuizz.txt";

        public static void Afficher()
        {
            string[] Lignes = File.ReadAllLines(PATH, Encoding.UTF8);

            Console.WriteLine($"Nombre total de jeux : {Lignes.Length - 1}");


            List<int> scores = new List<int>();
            List<string> erreurs = new List<string>();
            List<int> statQuestions = new List<int>();
            for (int i = 1; i < Lignes.Length; i++)
            {
                string[] scoreErreurs = Lignes[i].Split('/');
                string score = scoreErreurs[0];
                erreurs.Add(scoreErreurs[1]);
                scores.Add(Convert.ToInt32((score[score.Length - 2].ToString() + score[score.Length - 1].ToString()).ToString().Trim()));
            }
            Console.WriteLine($"Score moyen : {scores.Average()}");

            foreach (var item in erreurs)
            {
                if (!string.IsNullOrEmpty(item.Split('\t')[1]))
                {
                    string[] erreurQuestions = item.Split('\t')[1].Remove(0, 1).Split(',');

                    foreach (var e in erreurQuestions)
                    {
                        if (int.TryParse(e, out int b))
                            statQuestions.Add(Convert.ToInt32(e));
                    }
                }
            }

            Console.WriteLine($"Pourcentage de bonnes réponses pour les questions : ");

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"Question {i} : " +
                    $"{(Convert.ToDouble((Lignes.Length - 1) - statQuestions.Count(s => s == i)) / (Lignes.Length - 1)) * 100}%");
            }
        }
    }
}
