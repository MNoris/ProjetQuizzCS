using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizzCSharp
{
    class DAL
    {
        /// <summary>
        /// Constante représentant le chemin du fichier dans lequel les questions sont stockées
        /// </summary>
        public const string PATH = "..\\..\\..\\QCM.txt";

        /// <summary>
        /// Parcours le fichier correspondant au path et créé les questions et réponses
        /// </summary>
        /// <returns>Retourne le liste de questions créées</returns>
        static public List<Question> GetQuestions()
        {
            string[] file = File.ReadAllLines(PATH, Encoding.UTF8);
            var questions = new List<Question>();

            Question question = new Question("");
            Réponse réponse;

            //Selon différents critères, pour chaque ligne du fichier, créé une question,
            //une réponse, ou ajoute les réponses dans la question.
            foreach (var item in file)
            {
                if (item.ToLower().Contains("question"))
                {
                    question = new Question(item);
                }
                else if (item == "")
                {
                    questions.Add(question);
                }
                else if (item[0] >= 65 && item[0] <= 68)
                {
                    réponse = new Réponse(item, false);
                    question.Réponses.Add(réponse);
                }
                else if (item.StartsWith('*'))
                {
                    réponse = new Réponse(item.Remove(0, 1), true);
                    question.Réponses.Add(réponse);
                }

                if (item == file[file.Length - 1])
                {
                    questions.Add(question);
                }
            }

            return questions;
        }
    }
}
