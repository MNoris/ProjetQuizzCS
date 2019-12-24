using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizzCSharp
{
    class Résultats
    {
        const string PATH = "C:\\Quizz\\RésultatQuizz.txt";

        public static void CompléterFichier(Joueur joueur, int score, List<int> erreurs)
        {
            string stringErreurs = erreurs.Count > 0 ? erreurs[0].ToString(): string.Empty;

            for (int i = 1; i < erreurs.Count; i++)
            {
                stringErreurs += $",{erreurs[i]}";
            }

            using (StreamWriter sw = new StreamWriter(PATH, true))
            {
                sw.WriteLine(string.Format("{0:yyyy-dd-MM}\t{1,16}\t{2,2}/10\t{3,20}", DateTime.Now, joueur.GetNomPrénom(), score, stringErreurs));
            }
        }
    }
}
