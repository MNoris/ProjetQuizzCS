using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuizzCSharp
{
    class Partie
    {
        public List<Question> questions { get; set; }
        public int Score { get; set; }
        public List<int> Erreurs { get; set; }

        public void InitialiserPartie()
        {
            questions = DAL.GetQuestions();
            Score = 0;
            Erreurs = new List<int>();
        }

        public void PoserQuestions()
        {
            string saisie;
            int i = 1;

            foreach (var q in questions)
            {
                saisie = string.Empty;

                AfficherQuestionRéponses(q);
                Console.WriteLine();

                while (!VérifierSaisie(saisie))
                {
                    Console.WriteLine("Entrez la ou les réponses que vous pensez correcte(s)" +
                        ", dans l'ordre, en majuscule(s) et sans espaces. (ex : AC)");

                    saisie = Console.ReadLine();
                }

                if (saisie.Equals(q.GetBonnesRéponses()))
                    Score++;
                else
                    Erreurs.Add(i);

                i++;
                Console.Clear();
            }
        }

        public void AfficherQuestionRéponses(Question q)
        {
            Console.WriteLine(q.Libellé);
            foreach (var r in q.Réponses)
            {
                Console.WriteLine(r.Libellé);
            }
        }

        public bool VérifierSaisie(string saisie)
        {
            if (Regex.IsMatch(saisie, "[A-D]"))
                return true;
            return false;
        }

        public void AfficherRésultat()
        {
            Console.WriteLine($"Votre résultat : {Score}/{questions.Count}\n");

            foreach (var i in Erreurs)
            {
                AfficherQuestionRéponses(questions[i - 1]);

                Console.WriteLine($"Réponse(s) correcte(s) : {questions[i - 1].GetBonnesRéponses()}");
                Console.WriteLine();
            }
        }
    }
}
