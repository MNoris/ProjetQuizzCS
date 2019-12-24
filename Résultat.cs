using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizzCSharp
{
    class Résultat
    {
        /// <summary>
        /// Constante représentant le chemin du fichier de résultats
        /// </summary>
        const string PATH = "..\\..\\..\\RésultatsQuizz.txt";

        /// <summary>
        /// Complète le fichier avec les résultats de la session de jeu passés en paramètres
        /// </summary>
        /// <param name="joueur">Objet joueur ayant participé à la session</param>
        /// <param name="score">Score de la session</param>
        /// <param name="erreurs">Liste d'erreurs de la session</param>
        public static void CompléterFichier(Joueur joueur, int score, List<int> erreurs)
        {
            string stringErreurs = erreurs.Count > 0 ? erreurs[0].ToString(): string.Empty;

            for (int i = 1; i < erreurs.Count; i++)
            {
                stringErreurs += $",{erreurs[i]}";
            }

            using (StreamWriter sw = new StreamWriter(PATH, true))
            {
                sw.WriteLine(string.Format("{0:yyyy-dd-MM}\t{1,16}\t{2,2}/10\t{3,20}", DateTime.Now, joueur.ToString(), score, stringErreurs));
            }
        }
    }
}
