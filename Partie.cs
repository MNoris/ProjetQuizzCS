using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuizzCSharp
{
    class Partie
    {
        /// <summary>
        /// La liste de questions à poser
        /// </summary>
        public List<Question> Questions { get; set; }
        /// <summary>
        /// Score de la session
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Questions à lesquelles l'utilisateur à mal répondu durant la session
        /// </summary>
        public List<int> Erreurs { get; set; }

        /// <summary>
        /// Initialise l'objet partie à son état par défaut
        /// </summary>
        public void InitialiserPartie()
        {
            Questions = DAL.GetQuestions();
            Score = 0;
            Erreurs = new List<int>();
        }

        /// <summary>
        /// Lance la procédure de questions / réponses
        /// </summary>
        public void PoserQuestions()
        {
            string saisie;
            int i = 1;

            foreach (var q in Questions)
            {
                saisie = string.Empty;

                AfficherQuestionRéponses(q);
                Console.WriteLine();

                //Tant que la saisie est invalide, on re-demande à l'utilisateur de saisir sa/ses réponse(s)
                while (!VérifierSaisie(saisie))
                {
                    Console.WriteLine("Entrez la ou les réponses que vous pensez correcte(s)" +
                        ", dans l'ordre, en majuscule(s) et sans espaces. (ex : AC)");

                    saisie = Console.ReadLine();
                }

                //Incrémente le score de l'utilisateur, ou ajoute une erreur dans la liste d'erreurs
                //si la réponse de l'utilisateur est incorrecte
                if (saisie.Equals(q.GetBonnesRéponses()))
                    Score++;
                else
                    Erreurs.Add(i);

                i++;
                Console.Clear();
            }
        }

        /// <summary>
        /// Affiche une question et ses réponses en fonction de l'objet question passé en paramètre
        /// </summary>
        /// <param name="q">L'objet Question à afficher</param>
        public void AfficherQuestionRéponses(Question q)
        {
            Console.WriteLine(q.Libellé);
            foreach (var r in q.Réponses)
            {
                Console.WriteLine(r.Libellé);
            }
        }

        /// <summary>
        /// Vérifie le format de réponse de l'utilisateur
        /// </summary>
        /// <param name="saisie">Saisie de l'utilisateur</param>
        /// <returns>Booléen représentant la validité de la saisie</returns>
        public bool VérifierSaisie(string saisie)
        {
            if (Regex.IsMatch(saisie, "[A-D]"))
                return true;
            return false;
        }

        /// <summary>
        /// Affiche le résultat de la session du joueur, et les bonnes réponses aux questions 
        /// auxquelles il a mal répondu
        /// </summary>
        public void AfficherRésultat()
        {
            Console.WriteLine($"Votre résultat : {Score}/{Questions.Count}\n");

            //Pour chaque erreur, affiche la question, les réponses, et la bonne réponse
            foreach (var i in Erreurs)
            {
                AfficherQuestionRéponses(Questions[i - 1]);

                Console.WriteLine($"Réponse(s) correcte(s) : {Questions[i - 1].GetBonnesRéponses()}");
                Console.WriteLine();
            }
        }
    }
}
